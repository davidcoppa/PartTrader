import { Component, Input, OnInit } from '@angular/core';
import { first } from 'rxjs';
import { Parts } from 'src/app/Model/Parts';
import { ServerService } from 'src/app/services/server.service';

@Component({
  selector: 'app-catalogue',
  templateUrl: './catalogue.component.html',
  styleUrls: ['./catalogue.component.css']
})
export class CatalogueComponent implements OnInit {

  @Input() dataFromFilter: Parts[];
  public partsList: Parts[]=[];

  constructor(
    private serverService: ServerService
    ) {}


  ngOnInit(): void {
    if (this.dataFromFilter == null){
      this.GetAll();
    }
  }
  
  ngOnChanges() {
    if (this.dataFromFilter != null) {
      this.partsList=this.dataFromFilter;
    } else {
      this.GetAll()
    }
  }

  GetAll() {
    this.serverService.getFullCatalogue()
      .pipe(first())
      .subscribe({
        next: (data) => {
          this.partsList = data;
        },
        error: (e) => {
          window.alert("an error has occurred: "+e);
        },
        complete: () => console.info('complete')
      })
  }
}
