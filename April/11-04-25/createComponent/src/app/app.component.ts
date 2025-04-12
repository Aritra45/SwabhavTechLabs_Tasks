import { Component, Input, ViewChild } from '@angular/core';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'createComponent';
  
  getId = ''
  getData(data:any){
    this.getId = data
  }
}
