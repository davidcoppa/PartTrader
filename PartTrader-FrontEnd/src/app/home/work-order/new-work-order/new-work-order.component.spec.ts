import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { WorkOrderPartsTrader } from 'src/app/Model/WorkOrderPartsTrader';
import { ServerService } from 'src/app/services/server.service';

import { NewWorkOrderComponent } from './new-work-order.component';

describe('NewWorkOrderComponent', () => {
  let component: NewWorkOrderComponent;
  let fixture: ComponentFixture<NewWorkOrderComponent>;
  let serverService: ServerService
  let httpTestingController: HttpTestingController;
  let WorkOrder: WorkOrderPartsTrader[];
  let baseUrl = 'https://localhost:44319/api/WorkOrder/CreateWorkOrder'

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],

      declarations: [NewWorkOrderComponent]
    })
      .compileComponents();

    httpTestingController = TestBed.get(HttpTestingController);
    WorkOrder=[{
      partCode:"Ford1234",
      partId:"1234"
    }]

  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewWorkOrderComponent);
    component = fixture.componentInstance;
    serverService = fixture.debugElement.injector.get(ServerService);
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  //CreateWorkOrder
  it('should create a work Order', async () => {
    let result: WorkOrderPartsTrader[];

    serverService.CreateWorkOrder(WorkOrder).subscribe(
      x => {
        result = x;
      }
    );
    const req = httpTestingController.expectOne({
      method: "POST",
      url: baseUrl
    });

    req.flush(WorkOrder);

    fixture.detectChanges();

    fixture.whenStable().then(
      () => {
        expect(result[0].partCode).toEqual(WorkOrder[0].partCode);
      }
    );
  });




});
