import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Parts } from '../Model/Parts';
import { WorkOrderPartsTrader } from '../Model/WorkOrderPartsTrader';
import { PartsFilter } from '../Model/PartsFilter';


@Injectable({
  providedIn: 'root'
})
export class ServerService {
  
  ApiURL = 'https://localhost:44319';
  //https://localhost:44319

  constructor(private http: HttpClient) { }
 
  getFullCatalogue() {
    return this.http.get<Parts[]>(this.ApiURL+'/api/Catalogue/GetCatalogueList');
  }

  FindCompatibleParts(filter:PartsFilter){
    return this.http.post<Parts[]>(this.ApiURL+'/api/Parts/FindCompatibleParts',filter)
    
  }

  CreateWorkOrder(workOrderItems:WorkOrderPartsTrader[]){
    return this.http.post<WorkOrderPartsTrader[]>(this.ApiURL+'/api/WorkOrder/CreateWorkOrder',workOrderItems)
    
  }
}
