import { Component, OnInit } from '@angular/core';
import { NavigationStart, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  ngOnInit(): void {
    this.route.events.subscribe(event => {
      if (event instanceof NavigationStart) {
        let url = (<NavigationStart>event).url;
        if (url !== url.toLowerCase()) {
          this.route.navigateByUrl((<NavigationStart>event).url.toLowerCase());
        }
      }
    });  }
    constructor(private route: Router){

    }
  title = 'PartTrader-FrontEnd';

 

}
