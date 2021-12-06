import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Parts } from 'src/app/Model/Parts';
import { PartsFilter } from 'src/app/Model/PartsFilter';
import { ServerService } from 'src/app/services/server.service';

import { CompatiblePartsComponent } from './compatible-parts.component';

describe('CompatiblePartsComponent', () => {
  let component: CompatiblePartsComponent;
  let fixture: ComponentFixture<CompatiblePartsComponent>;
  let serverService: ServerService

  let httpTestingController: HttpTestingController;
  let partsFilter: PartsFilter;
  let baseUrl = 'https://localhost:44319/api/Parts/FindCompatibleParts'

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [CompatiblePartsComponent]
    }).compileComponents();

    httpTestingController = TestBed.get(HttpTestingController);

    partsFilter = {
      PartId: "1234",
      PartCode: "asd465",
    };

  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CompatiblePartsComponent);
    component = fixture.componentInstance;
    serverService = fixture.debugElement.injector.get(ServerService);
    fixture.detectChanges();

  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should get compatible part by PartID from service', async () => {
    let result: Parts[];

    serverService.FindCompatibleParts(partsFilter).subscribe(
      x => {
        result = x;
      }
    );
    const req = httpTestingController.expectOne({
      method: "POST",
      url: baseUrl
    });

    req.flush(partsFilter);

    fixture.detectChanges();

    fixture.whenStable().then(
      () => {
        expect(result[0].partId).toEqual(partsFilter.PartId);
      }
    );
  });

  it('should get compatible part by PartCode from service', async () => {
    let result: Parts[];

    serverService.FindCompatibleParts(partsFilter).subscribe(
      x => {
        result = x;
      }
    );
    const req = httpTestingController.expectOne({
      method: "POST",
      url: baseUrl
    });

    req.flush(partsFilter);

    fixture.detectChanges();

    fixture.whenStable().then(
      () => {
        expect(result[0].partCode).toEqual(partsFilter.PartCode);
      }
    );
  });

});
