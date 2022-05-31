import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomerComponent } from './customer/customer.component';
import { GetDeleteCustomerComponent } from './customer/get-delete-customer/get-delete-customer.component';
//import { GetCreateEditCustomerComponent } from './customer/get-create-edit-customer/get-create-edit-customer.component';
import { CreateEditCustomerComponent } from './customer/create-edit-customer/create-edit-customer.component';
import { SharedcustomerserviceService } from './sharedcustomerservice.service';

import {HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    CustomerComponent,
    GetDeleteCustomerComponent,
    //GetCreateEditCustomerComponent,
    CreateEditCustomerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [SharedcustomerserviceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
