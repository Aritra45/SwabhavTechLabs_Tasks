import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'ProductApp';

  products=[
    {id:1,name:"Watch",color:"Black",price:250,available:"Available",image:"assets/Watch.jpg", details:"This is Watch"},
    {id:2,name:"Mobile",color:"Blue",price:500,available:"Available",image:"assets/Mobile.jpg", details:"This is Mobile"},
    {id:3,name:"Refrigerator",color:"Gray",price:3000,available:"Not Available",image:"assets/Refrigerator.jpg", details:"This is Refrigerator"},
    {id:4,name:"Television",color:"White",price:4000,available:"Available",image:"assets/Television.jpg", details:"This is Television"},
  ]

  checkAvailable(value:any){
    if(value == "Available"){
      return "green"
    }
    else{
      return "red"
    }
  }

  notify(){
    alert("We will notify when the product is available, Thank You!!!")
  }

  buy(value:any){
    alert('Thank You for buying')
  }

  details(value:any, value2:any){
    console.log(`hi ${value} ${value2}`);
    
  }
}
