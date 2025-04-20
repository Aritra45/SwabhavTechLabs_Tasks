import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'customDirectives';
  custom = true

  bgColor= 'aqua'
  defaultColor = 'red'
}
