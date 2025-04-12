import { Component, ElementRef, ViewChild } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'directives';
  condition = true;
  players = ["Aritra", "Abhishek"]
  playerWithAge = [
    {name:"Rahul", age: 70},
    {name:"Virat", age: 20}
  ]

  students = [
    {name:"Aritra", marks:95},
    {name:"Abhishek", marks:85},
    {name:"Pradnya", marks:75},
    {name:"Garvita", marks:50},
  ]


  getMarks(marks:any){
    if(marks>=90){
      return "green"
    }
    else if(marks>=80 && marks<90){
      return "orenge"
    }
    else if(marks>=70 && marks<80){
      return "yellow"
    }
    else if(marks<60){
      return "red"
    }
    else{
      return "other"
    }
  }


// displayName(value:any){
//   alert(value)
// }

  @ViewChild('inputbox')
  inputText! : ElementRef

  displayName(){
    alert(this.inputText.nativeElement.value)
  }
}
