import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'firstProject';
  link = 'https://mail.google.com/mail/u/1/#inbox?compose=CllgCJZXhsjrXqmBlHPrJJzzCwJMQfJPMwQsRgcrhqftPmsdMjhXlVSjqvjXZpPnKxZjQWpHrbV';
  image = 'assets/logo.jpeg'
  number = 1;
  min = 0;
  max = 18;
  players = ["aritra", "abhishek"]
  increment(){
    if(this.number != this.max){
    this.number+=1
    }
    else{
      alert("Limit Reached")
    }
  }
  decrement(){
    if(this.number != this.min){
    this.number-=1
    }
    else{
      alert("no more decrement")
    }
  }
}
