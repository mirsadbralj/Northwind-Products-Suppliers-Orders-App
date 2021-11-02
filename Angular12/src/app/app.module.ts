import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductComponent } from './product/product.component';
import { ShowProdComponent } from './product/show-prod/show-prod.component';
import { SharedService } from './shared.service';
import { NO_ERRORS_SCHEMA } from '@angular/core';

import {HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddEditProdComponent } from './product/add-edit-prod/add-edit-prod.component';
import { SupplierComponent } from './supplier/supplier.component';
import { ShowSuppComponent } from './supplier/show-supp/show-supp.component';
import { OrderComponent } from './order/order.component';
import { ShowOrdComponent } from './order/show-ord/show-ord.component';
import { CategoryComponent } from './category/category.component';
@NgModule({
  declarations: [
    AppComponent,
    ProductComponent,
    ShowProdComponent,
    AddEditProdComponent,
    SupplierComponent,
    ShowSuppComponent,
    OrderComponent,
    ShowOrdComponent,
    CategoryComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent],
  schemas:[
    CUSTOM_ELEMENTS_SCHEMA,
    NO_ERRORS_SCHEMA
  ]
})
export class AppModule { }
