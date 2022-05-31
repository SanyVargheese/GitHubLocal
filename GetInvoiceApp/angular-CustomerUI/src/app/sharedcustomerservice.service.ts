import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import {Observable} from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class SharedcustomerserviceService {
  readonly APIUrl = "http://localhost:5001/api"; 
  readonly apiurltest = "https://getinvoices.azurewebsites.net/api/Customers";

  constructor(private http:HttpClient) { }

  getCustomerList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Customer');
  }

  CreateCustomer(val:any){
    return this.http.post(this.APIUrl+'/Customer', val);

  }
  
  UpdateCustomer(val:any){
    return this.http.put(this.APIUrl+'/Customer/'+ val,val);
  }
  DeleteCustomer(val:any){
    return this.http.delete(this.APIUrl+'/Customer/'+ val);
  }

  GetAllCustomers():Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl+'/Customer/GetAllCustomers');
  }

}
