import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { CatalogueComponent } from './home/catalogue/catalogue.component';
import { WorkOrderComponent } from './home/work-order/work-order.component';
import { NewWorkOrderComponent } from './home/work-order/new-work-order/new-work-order.component';
import { NavComponent } from './home/nav/nav.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FilterPipe } from './Helpers/filter.pipe';
import { CompatiblePartsComponent } from './home/compatible-parts/compatible-parts.component';
import { CompatiblePartsService } from './services/compatibleParts.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CatalogueComponent,
    WorkOrderComponent,
    NewWorkOrderComponent,
    NavComponent,
    FilterPipe,
    CompatiblePartsComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule

  ],
  providers: [CompatiblePartsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
