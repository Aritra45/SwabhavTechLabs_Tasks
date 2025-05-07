import { Component, HostListener } from '@angular/core';
import { Router } from '@angular/router';
import { AuthServiceService } from '../auth-login/login/auth-service.service';
import { jwtDecode } from 'jwt-decode';
import { response } from 'express';


@Component({
  selector: 'app-logout',
  standalone: false,
  templateUrl: './logout.component.html',
  styleUrl: './logout.component.css'
})
export class LogoutComponent {
  constructor(private router:Router, private as:AuthServiceService){}
 

  logout(){
    const token = localStorage.getItem('token')
    if(!token){
      alert("token not found")
      return
    }
    const decodeToken:any = jwtDecode(token)
    const email = decodeToken.Id
    this.as.logout(email).subscribe(
      (response)=>{
        alert("You are Logged Out Successfully!!!")
        localStorage.removeItem('token')
        this.router.navigate(['/auth-login/login'])
      },
      (error) => {
        console.error("LogOut Failed:", error);
        alert("LogOut Failed.");
      }
    )
    
  }

  ngOnInit() {
    window.addEventListener('beforeunload', (event) => {
      const nav = performance.getEntriesByType("navigation")[0] as PerformanceNavigationTiming;
      if (nav && nav.type !== 'reload') {
        localStorage.removeItem('token');
      }
    });
  }
}
