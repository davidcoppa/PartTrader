import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Subscription } from 'rxjs';
import { Parts } from 'src/app/Model/Parts';
import { CompatiblePartsService } from 'src/app/services/compatibleParts.service';
import { DataService } from 'src/app/services/data.Service';

@Component({
  selector: 'app-compatible-parts',
  templateUrl: './compatible-parts.component.html',
  styleUrls: ['./compatible-parts.component.css'],
  providers: [CompatiblePartsService]
})
export class CompatiblePartsComponent implements OnInit, OnDestroy {

  resultData: Parts[];
  subscriptionName: Subscription;
  constructor(
    private compatiblePartsService: CompatiblePartsService,
    private dataService: DataService
  ) {
    this.subscriptionName = this.dataService.getUpdate().subscribe
      (data => { //message contains the data sent from service
        this.resultData = data;
      });
  }

  ngOnDestroy(): void {
    this.subscriptionName.unsubscribe();
  }


  public searchParts: FormGroup = new FormGroup({
    partNumber: new FormControl()
  })

  ngOnInit(): void {
  }

  Clear() {
    this.searchParts.reset();
  }

  onSubmit() {
    this.compatiblePartsService.GetCompatibles(this.searchParts.value.partNumber);
  }
}

