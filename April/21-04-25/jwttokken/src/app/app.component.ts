import { Component } from '@angular/core';
import { AuthServiceService } from './auth-service.service';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'jwttokken';
  userEmail = '' 
  password = ''
  constructor(private authService:AuthServiceService, private router:Router){}
  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }
  
  navigateToLogin1() {
    
    // this.router.navigate(['/login'], { queryParams: { type: userType } });
    this.authService.login1(this.userEmail, this.password).subscribe(response => {
      localStorage.setItem('token', response.token);
 
      const token = localStorage.getItem('token');
      if (token) {
        const decodedToken: any = jwtDecode(token);
        var loginRole = decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] || null; // Assuming "role" is in the payload
        alert('Login Successful' + loginRole);
        if (loginRole == 'Admin')
          this.router.navigate(['/home']);
    
        if (loginRole == 'Bank')
          this.router.navigate(['/home']);
        if (loginRole == 'Company')
          this.router.navigate(['/home']);
      }

      return null;
 
 
    }, error => {
      alert('Login Failed');
    });
  }
}
