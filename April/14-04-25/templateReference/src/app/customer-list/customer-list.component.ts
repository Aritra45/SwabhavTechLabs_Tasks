import { Component, EventEmitter, Output } from '@angular/core';
import { Customer } from './customer';

@Component({
  selector: 'app-customer-list',
  standalone: false,
  templateUrl: './customer-list.component.html',
  styleUrl: './customer-list.component.css'
})
export class CustomerListComponent {
  customers:Customer[]=[
    {customerNo:1, name:"Ganesh",address:"Nashik",city:"Nashik",country:"India"},
    {customerNo:2, name:"Ram",address:"Mumbai",city:"Mumbai",country:"India"},
    {customerNo:3, name:"Vithu",address:"Pune",city:"Pune",country:"India"}
  ]

  // showCustomers: Customer[] = []

  // getData(index: number) {
  //   this.showCustomers.push(this.customers[index]);

  @Output() sendtoParent: EventEmitter<any> = new EventEmitter<any>

  

  getData(index: number){
    const Index = this.customers[index]
    // const data = this.showCustomers.push(this.customers[index]);
    this.sendtoParent.emit(Index)
    }
}

