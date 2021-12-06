import { Injectable, OnInit } from "@angular/core";
import { first } from "rxjs";
import { Parts } from "../Model/Parts";
import { PartsFilter } from "../Model/PartsFilter";
import { DataService } from "./data.Service";
import { ServerService } from "./server.service";

@Injectable({
  providedIn: 'root'
})


export class CompatiblePartsService {


  compatibleItem: PartsFilter;
  resultData: Parts[];
  constructor(
    private serverService: ServerService,
    private dataService: DataService

  ) { }

SplitPartNumber(partNumber: string){
  var partN = partNumber.trim();

  this.compatibleItem = {
    PartId: "",
    PartCode: ""
  };
  if (partN.includes('-')) {
    var fields = partN.split('-');
    this.compatibleItem.PartId = fields[0];
    this.compatibleItem.PartCode = fields[1];
  } else {
    if (!isNaN(+partN) && partN.length <= 4) {
      this.compatibleItem.PartId = partN;
    }
    else {
      this.compatibleItem.PartCode = partN;
    }
  }
}

  GetCompatibles(partNumber: string): Parts[] {

    this.SplitPartNumber(partNumber)

    this.serverService.FindCompatibleParts(this.compatibleItem)
      .pipe(first())
      .subscribe({
        next: (data) => {
          this.dataService.sendUpdateObject(data);

        },
        error: (e) => {
          window.alert("an error has occurred: " + e.error);
        },
        complete: () => console.info('complete')
      });

    return this.resultData;

  }
}