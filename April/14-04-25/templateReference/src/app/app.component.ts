import { Component } from '@angular/core';
import { Customer } from './customer-list/customer';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'templateReference';
  // arr:any
  showCustomers: Customer[] = []
  getData(data:any){
    // this.arr = data
    this.showCustomers.push(data);
  }
}
