import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-logout',
  standalone: false,
  templateUrl: './logout.component.html',
  styleUrl: './logout.component.css'
})
export class LogoutComponent {
  constructor(private router:Router){}
 

  logout(){
    alert("You are Logged Out Successfully!!!")
    localStorage.removeItem('token')
    this.router.navigate(['/auth-login/login'])
  }
}
