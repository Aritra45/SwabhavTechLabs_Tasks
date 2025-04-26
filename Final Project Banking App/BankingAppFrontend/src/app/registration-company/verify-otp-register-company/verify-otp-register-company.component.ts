import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthServiceService } from '../auth-service.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-verify-otp-register-company',
  standalone: false,
  templateUrl: './verify-otp-register-company.component.html',
  styleUrl: './verify-otp-register-company.component.css'
})
export class VerifyOtpRegisterCompanyComponent {
  registerForm: FormGroup;
  

  constructor(private fb: FormBuilder, private authService: AuthServiceService, private router: Router) {
    const state = history.state as { email?: string };
    console.log('State:', state);
    this.registerForm = this.fb.group({
      companyEmail: [{ value: state?.email || '', disabled: true }, [Validators.required, Validators.email]],
      otp: ['', Validators.required],
    });
  }

  

  onSubmit() {
    const body = {
      CompanyEmail: this.registerForm.getRawValue().companyEmail,  
      OTP: this.registerForm.value.otp,
    };
  
    this.authService.doVerify(body).subscribe({
      next: (res) => {
        alert('Registration successful!!!');
        this.registerForm.reset();
        this.router.navigate(['/auth-login/login']);
      },
      error: (err) => {
        console.error('Verification failed:', err);
        alert('InValid OTP. Please try again');
      }
    });
  
    console.log('Form submitted!', body);
  }
  
  
}
