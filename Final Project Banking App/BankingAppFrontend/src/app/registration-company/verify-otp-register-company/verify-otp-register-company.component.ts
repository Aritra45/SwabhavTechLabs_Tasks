import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthServiceService } from '../auth-service.service';
import { Router } from '@angular/router';
import { error } from 'console';
import { AlertBoxMainComponent } from '../../alert-box-main/alert-box-main.component';
import { MatDialog } from '@angular/material/dialog';


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

  constructor(private fb: FormBuilder, private authService: AuthServiceService, private router: Router, private dialog: MatDialog) {
    const state = history.state as { email?: string };
    console.log('State:', state);
    this.registerForm = this.fb.group({
      companyEmail: [{ value: state?.email || '', disabled: true }, [Validators.required, Validators.email]],
      otp: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(6)]],
    });
  }


  isLoading = false
  message: any
  onSubmit() {
    const body = {
      CompanyEmail: this.registerForm.getRawValue().companyEmail,
      OTP: this.registerForm.value.otp,
    };
    this.isLoading = true
    this.authService.doVerify(body).subscribe({
      next: (res) => {

        this.message = 'Registration successful!!!';

        const dialogalert = this.dialog.open(AlertBoxMainComponent, {
          width: '500px',
          height: '300px',
          data: this.message
        })

        setTimeout(() => {
          dialogalert.close();
        }, 3000);
        this.isLoading = false
        this.registerForm.reset();
        this.router.navigate(['/auth-login/login']);
      },
      error: (err) => {
        console.error('Verification failed:', err);
        this.message = 'InValid OTP. Please try again';
        const dialogalert = this.dialog.open(AlertBoxMainComponent, {
          width: '500px',
          height: '300px',
          data: this.message
        })

        setTimeout(() => {
          dialogalert.close();
        }, 3000);
      }
    });

    console.log('Form submitted!', body);
  }
  isresendLoading = false
  resendOtp() {
    const companyEmail = this.registerForm.getRawValue().companyEmail;
    if (!companyEmail) return;
    this.isresendLoading = true
    this.authService.resendOtp(companyEmail).subscribe({
      next: (res) => {
        this.isresendLoading = false
        this.message = 'A new OTP has been sent to your email.';

        const dialogalert = this.dialog.open(AlertBoxMainComponent, {
          width: '500px',
          height: '300px',
          data: this.message
        })

        setTimeout(() => {
          dialogalert.close();
        }, 3000);
        this.startTimer();
      },
      error: (err) => {
        console.error('Error resending OTP:', err);
        this.message = 'Failed to resend OTP. Please try again.';
        const dialogalert = this.dialog.open(AlertBoxMainComponent, {
          width: '500px',
          height: '300px',
          data: this.message
        })

        setTimeout(() => {
          dialogalert.close();
        }, 3000);
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
