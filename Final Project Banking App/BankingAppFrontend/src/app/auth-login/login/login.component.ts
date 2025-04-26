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

  // onSubmit() {
  //   if (this.form.valid) {
  //     console.log(this.form.value);
  //     alert('Form Submitted!');
  //   }
  // }

  captchaResolved: boolean = false;
  captchaToken: string = '';

  onCaptchaResolved(captchaResponse: string | null): void {
    this.captchaResolved = !!captchaResponse;
    this.captchaToken = captchaResponse ?? '';
  }


  onSubmit() {
    if(!this.captchaResolved){
      alert("check the captcha!!!")
    }
    if (this.captchaResolved) {
    this.authService.login1(this.userEmail, this.password).subscribe(response => {
      localStorage.setItem('token', response.token);

      const token = localStorage.getItem('token');
      if (token) {
        const decodedToken: any = jwtDecode(token);
        var loginRole = decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] || null; // Assuming "role" is in the payload
        alert(`Login Successful ${loginRole}`);
        // window.location.reload()
        if (loginRole == 'Admin')
          this.router.navigate(['/admin-dashboard']);
        if (loginRole == 'Bank')
          this.router.navigate(['/bank-dashboard']);
        if (loginRole == 'Company')
          this.router.navigate(['/company-dashboard']);
      }

      return null;


    }, error => {
      alert('Login Failed');
    });
  }
}
}
