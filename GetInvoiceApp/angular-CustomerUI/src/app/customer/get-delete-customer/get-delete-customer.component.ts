import { Component, OnInit } from '@angular/core';
import { SharedcustomerserviceService } from 'src/app/sharedcustomerservice.service';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-get-delete-customer',
  templateUrl: './get-delete-customer.component.html',
  styleUrls: ['./get-delete-customer.component.css']
})
export class GetDeleteCustomerComponent implements OnInit {


  CustomerList$!:Observable<any[]>;

  constructor(private service : SharedcustomerserviceService) { }
  //CustomerList:any=[];
  

  ngOnInit(): void {
    this.CustomerList$ = this.service.GetAllCustomers();
    //this.GetAllCustomers();
  } 


  // GetAllCustomers(){
  //   this.service.GetAllCustomers().subscribe(data=> {
  //       this.CustomerList=data;
  //   });
  //}
}
