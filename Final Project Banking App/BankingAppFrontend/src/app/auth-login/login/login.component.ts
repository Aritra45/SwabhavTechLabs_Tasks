import { ChangeDetectorRef, Component } from '@angular/core';
import { AuthServiceService } from './auth-service.service';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  userEmail = '';
  password = '';
  loggedIn = false;

  hidePassword: boolean = true;

  togglePasswordVisibility() {
    this.hidePassword = !this.hidePassword;
  }

  constructor(
    private authService: AuthServiceService,
    private router: Router,
    private cdRef: ChangeDetectorRef
  ) {
    this.loggedIn = this.isLoggedIn();
  }

  isLoggedIn(): boolean {
    if (typeof window !== 'undefined' && localStorage) {
      return !!localStorage.getItem('token');
    }
    return false;
  }



  captchaResolved: boolean = false;
  captchaToken: string = '';

  onCaptchaResolved(captchaResponse: string | null): void {
    this.captchaResolved = !!captchaResponse;
    this.captchaToken = captchaResponse ?? '';
  }

  isLoading = false;
  onSubmit() {
    if (!this.captchaResolved) {
      alert("Check the captcha!");
      return;
    }

    this.isLoading = true;  // Show spinner when submission starts

    this.authService.login1(this.userEmail, this.password).subscribe(response => {
      this.isLoading = false;  // Hide spinner once the response is received
      localStorage.setItem('token', response.token);

      const token = localStorage.getItem('token');
      if (token) {
        const decodedToken: any = jwtDecode(token);
        var loginRole = decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] || null;
        // alert(`Login Successful ${loginRole}`);

        // Navigate based on role
        if (loginRole === 'SuperAdmin') {
          this.router.navigate(['/admin-dashboard']);
        }else if (loginRole === 'Admin') {
          this.router.navigate(['/admin-dashboard']);
        }else if (loginRole === 'Bank') {
          this.router.navigate(['/bank-dashboard']);
        } else if (loginRole === 'Company') {
          this.router.navigate(['/company-dashboard']);
        }
      }
    }, error => {
      this.isLoading = false;  // Hide spinner if login fails
      alert('Login Failed');
    });
  }
}
