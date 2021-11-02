import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrderComponent } from './order/order.component';

import { ProductComponent } from './product/product.component';
import { SupplierComponent } from './supplier/supplier.component';
const routes: Routes = [
  {path:'product', component:ProductComponent},
  {path:'supplier', component:SupplierComponent},
  {path:'order', component:OrderComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
