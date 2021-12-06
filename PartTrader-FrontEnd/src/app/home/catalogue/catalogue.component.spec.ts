import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Parts } from 'src/app/Model/Parts';
import { ServerService } from 'src/app/services/server.service';

import { CatalogueComponent } from './catalogue.component';


describe('CatalogueComponent', () => {
  let component: CatalogueComponent;
  let fixture: ComponentFixture<CatalogueComponent>;
  let serverService: ServerService

  let httpTestingController: HttpTestingController;
  let catalogue: Parts[];
  let baseUrl = 'https://localhost:44319/api/Catalogue/GetCatalogueList'


  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [CatalogueComponent]
    }).compileComponents();

    httpTestingController = TestBed.get(HttpTestingController);

    catalogue = [{
      partId: "1234",
      partCode: "asd465",
      compatibleParts: [new Parts],
      description: "Ford focus engine",
      price: 1000
    }];


  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CatalogueComponent);
    component = fixture.componentInstance;
    serverService = fixture.debugElement.injector.get(ServerService);
    fixture.detectChanges();
  });


  it('should create', () => {
    expect(component).toBeTruthy();
  });

  // it('Should Get the full catalogue from server', async () => {
  //   let result: Parts[];  

  //   serverService.getFullCatalogue().subscribe(
  //     x => {
  //       result = x;
  //     }
  //   );
  //   const req = httpTestingController.expectOne({
  //     method: "GET",
  //     url: baseUrl
  //   });


  //   req.flush(catalogue);

  //   fixture.detectChanges();

  //   fixture.whenStable().then(
  //     () => {
  //       expect(result[0].partId).toEqual(catalogue[0].partId);
  //     }
  //   );  });


});
