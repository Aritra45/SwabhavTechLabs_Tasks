import { Component } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login-component',
  standalone: false,
  templateUrl: './login-component.component.html',
  styleUrl: './login-component.component.css'
})
export class LoginComponentComponent {
  constructor(private route:Router){}
  
  
  goRegistration(){
    this.route.navigate(['/register']);
    alert("Register OPage");
  }
  
  login(){
    this.route.navigate(['/registration']);
  }
}
