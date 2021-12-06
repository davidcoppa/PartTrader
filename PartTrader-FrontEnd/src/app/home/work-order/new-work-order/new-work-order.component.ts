import { Component, OnDestroy } from '@angular/core';
import {  FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { first, Subscription } from 'rxjs';
import { Parts } from 'src/app/Model/Parts';
import { PartsExclusion } from 'src/app/Model/PartsExclusionList';
import { WorkOrder } from 'src/app/Model/WorkOrder';
import { WorkOrderPartsTrader } from 'src/app/Model/WorkOrderPartsTrader';
import { CompatiblePartsService } from 'src/app/services/compatibleParts.service';
import { DataService } from 'src/app/services/data.Service';
import { ServerService } from 'src/app/services/server.service';
import ExclusionList from '../../../../assets/ExclusionList/Exclusions.json';


@Component({
  selector: 'app-new-work-order',
  templateUrl: './new-work-order.component.html',
  styleUrls: ['./new-work-order.component.css'],
  providers: [CompatiblePartsService]

})
export class NewWorkOrderComponent implements OnDestroy {

  subscriptionName: Subscription;
  resultData: Parts;

  workOrderList: WorkOrder[] = [];
  workOrderItems: boolean;
  workOrderPT: WorkOrderPartsTrader[] = [];


  //load the exclusion list
  public exclusionList: PartsExclusion[] = ExclusionList;


  constructor(private serverService: ServerService,
    private compatiblePartsService: CompatiblePartsService,
    private dataService: DataService
  ) {
    this.subscriptionName = this.dataService.getUpdate().subscribe
      (data => { //message contains the data sent from service
        this.resultData = data[0];
        this.UpdateTable();
      });

  }

  UpdateTable() {
    if (this.resultData != null) {

      if (this.resultData.compatibleParts.length > 0) {
        var compatibles = "";

        for (var i = 0; i < this.resultData.compatibleParts.length; i++) {
          compatibles = compatibles + (this.resultData.compatibleParts[i].partId + "-" + this.resultData.compatibleParts[i].partCode) + ",";
        }
        this.workOrderForm.value.compatibleParts = compatibles;

      }
      this.ShowRow();
    }
  }


  ngOnDestroy(): void {
    this.subscriptionName.unsubscribe();
  }

  get f() { return this.workOrderForm.controls; }

  public workOrderForm: FormGroup = new FormGroup({
    partNumber: new FormControl("", [Validators.required, Validators.pattern("^[0-9]{4}[-][a-zA-Z][a-zA-Z0-9]{3,}$")]),
    isOnStorage: new FormControl(),
    compatibleParts: new FormControl()
  })





  ClearOrder() {
    this.workOrderItems = false;
    this.workOrderList = [];
    this.workOrderForm.reset();
  }

  Add() {

    if (this.workOrderForm.invalid) {
      return;
    }

    //checking if the item is in the exclusion list
    var isOnStorage = this.exclusionList.find(x => x.PartNumber.toLowerCase() == this.workOrderForm.value.partNumber.toLowerCase()) ? true : false;
    this.workOrderForm.value.isOnStorage = isOnStorage;

    if (!isOnStorage) {

      this.compatiblePartsService.GetCompatibles(this.workOrderForm.value.partNumber);
    } else {
      this.ShowRow();
    }
  }

  ShowRow() {
    //copy the item into the list
    console.log(this.workOrderForm);

    let order: WorkOrder = Object.assign(new WorkOrder(), this.workOrderForm.value);
    this.workOrderList.push(order);


    //make visible the list items
    this.workOrderItems = true;
    this.workOrderForm.reset();
  }



  onSubmit() {

    var itemsList = this.workOrderList;
    for (var i = 0; i < itemsList.length; i++) {

      if (!itemsList[i].isOnStorage) {
        var fields = itemsList[i].partNumber.split('-');

        this.workOrderPT.push({ partCode: fields[1], partId: fields[0] })
      }
    };

    //check if I have amy element to send to Parts trader 
    if (this.workOrderPT.length > 0) {
      this.serverService.CreateWorkOrder(this.workOrderPT)
        .pipe(first())
        .subscribe({
          next: (data) => {

            window.alert("order created on Parts Trader successfully!")
            this.ClearOrder();

          },
          error: (e) => {
            window.alert("an error has occurred: " + e.error);
          },
          complete: () => console.info('complete')
        })

    }



  }


}
