import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'blurEvent';

  today = new Date();
  birth!: Date;
  age = 0;
  getAge(data: any) {
    this.birth = new Date(data.value); 
    this.age = (this.today.getFullYear() - this.birth.getFullYear()) 
  }
}