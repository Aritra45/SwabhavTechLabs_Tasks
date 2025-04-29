import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthServiceService } from '../auth-service.service';
import { Router } from '@angular/router';
import { error } from 'console';


@Component({
  selector: 'app-verify-otp-register-company',
  standalone: false,
  templateUrl: './verify-otp-register-company.component.html',
  styleUrl: './verify-otp-register-company.component.css'
})
export class VerifyOtpRegisterCompanyComponent {
  registerForm: FormGroup;
  isResendDisabled = false;
  timer = 0;
  private intervalId: any;

  constructor(private fb: FormBuilder, private authService: AuthServiceService, private router: Router) {
    const state = history.state as { email?: string };
    console.log('State:', state);
    this.registerForm = this.fb.group({
      companyEmail: [{ value: state?.email || '', disabled: true }, [Validators.required, Validators.email]],
      otp: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(6)]],
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
  
  resendOtp() {
    const companyEmail = this.registerForm.getRawValue().companyEmail;
    if (!companyEmail) return;
    
    this.authService.resendOtp(companyEmail).subscribe({
      next: (res) => {
        alert('A new OTP has been sent to your email.');
        this.startTimer();
      },
      error: (err) => {
        console.error('Error resending OTP:', err);
        alert('Failed to resend OTP. Please try again.');
      }
    });
  }
  startTimer() {
    this.isResendDisabled = true;
    this.timer = 120; 

    this.intervalId = setInterval(() => {
      this.timer--;
      if (this.timer === 0) {
        clearInterval(this.intervalId);
        this.isResendDisabled = false;
      }
    }, 1000);
  }
  
}
