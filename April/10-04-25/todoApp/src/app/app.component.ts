import { Component, ElementRef, ViewChild } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'todoApp';

  tasks:string[] =[]
  convertedTasks: string[]= []
  completedTasks:string[]=[]
  isPresent = false

  @ViewChild('inputBox')
  inputText!:ElementRef
  
  taskValue="";
  
  addTask() {
    this.taskValue = this.inputText.nativeElement.value;
    this.convertedTasks = this.tasks.map(task => task.toLowerCase())
    this.isPresent = this.convertedTasks.includes(this.taskValue.toLowerCase())
    if (this.taskValue && !this.isPresent) {
      this.tasks.push(this.taskValue);
      this.inputText.nativeElement.value = ''; 
    }
    else if(this.isPresent){
      alert("Task Already Present")
    }
    else{
      alert("Input is Empty")
    }
    
    
  }
  completed(index: number) {
    this.completedTasks.push(this.tasks[index]);
    this.tasks.splice(index, 1); 
  }

  deleteTask(index: number){
    this.tasks.splice(index, 1); 
  }

  deleteCompletedTask(index: number){
    this.completedTasks.splice(index, 1);
  }
}


