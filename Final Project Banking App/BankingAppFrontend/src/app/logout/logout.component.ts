import { Component, HostListener } from '@angular/core';
import { Router } from '@angular/router';
import { AuthServiceService } from '../auth-login/login/auth-service.service';
import { jwtDecode } from 'jwt-decode';
import { response } from 'express';
import { AlertBoxMainComponent } from '../alert-box-main/alert-box-main.component';
import { MatDialog } from '@angular/material/dialog';


@Component({
  selector: 'app-logout',
  standalone: false,
  templateUrl: './logout.component.html',
  styleUrl: './logout.component.css'
})
export class LogoutComponent {
  constructor(private router: Router, private as: AuthServiceService, private dialog: MatDialog) { }

  message: any
  logout() {
    const token = localStorage.getItem('token')
    if (!token) {
      alert("token not found")
      return
    }
    const decodeToken: any = jwtDecode(token)
    const email = decodeToken.Id
    const payload = JSON.parse(atob(token.split('.')[1])); // Decode JWT
    const role = payload['role'] || payload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] || '';
    this.as.logout(email).subscribe(
      (response) => {
        this.message = `${role} Logged Out Successfully`;
        const dialogalert = this.dialog.open(AlertBoxMainComponent, {
          width: '500px',
          height: '300px',
          data: this.message
        })

        setTimeout(() => {
          dialogalert.close();
        }, 3000);
        localStorage.removeItem('token')
        this.router.navigate(['/auth-login/login'])
      },
      (error) => {
        console.error("LogOut Failed:", error);
        alert("LogOut Failed.");
        this.message = 'LogOut Failed!';
        const dialogalert = this.dialog.open(AlertBoxMainComponent, {
          width: '500px',
          height: '300px',
          data: this.message
        })

        setTimeout(() => {
          dialogalert.close();
        }, 3000);
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
