import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CatalogueComponent } from './home/catalogue/catalogue.component';
import { CompatiblePartsComponent } from './home/compatible-parts/compatible-parts.component';
import { HomeComponent } from './home/home.component';
import { WorkOrderComponent } from './home/work-order/work-order.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'catalogue', component: CatalogueComponent },
  { path: 'workorder', component: WorkOrderComponent },
  { path: 'compatibleparts', component: CompatiblePartsComponent },
  

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
