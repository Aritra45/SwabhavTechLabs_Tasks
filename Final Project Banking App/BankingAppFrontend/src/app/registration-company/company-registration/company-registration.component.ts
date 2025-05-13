import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthServiceService } from '../auth-service.service';
import { Router } from '@angular/router';
import { AlertBoxMainComponent } from '../../alert-box-main/alert-box-main.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-company-registration',
  standalone: false,
  templateUrl: './company-registration.component.html',
  styleUrl: './company-registration.component.css'
})
export class CompanyRegistrationComponent {
  registerForm: FormGroup;
  aadharFile: File | null = null;
  panFile: File | null = null;

  hidePassword: boolean = true;

  togglePasswordVisibility() {
    this.hidePassword = !this.hidePassword;
  }

  constructor(private fb: FormBuilder, private authService: AuthServiceService, private router: Router, private dialog: MatDialog) {
    this.registerForm = this.fb.group({
      companyEmail: ['', [Validators.required, Validators.email]],
      companyName: ['', Validators.required],
      companyContactNumber: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10)]],
      companyAddress: ['', Validators.required],
      companyAccountNumber: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11)]],
      ifscNumber: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11)]],
      password: ['', [Validators.required, Validators.minLength(6), Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&]).{6,}$')]]
    });
  }

  onAadharFileSelected(event: Event) {
    const input = event.target as HTMLInputElement;
    if (input.files?.length) {
      this.aadharFile = input.files[0];
    }
  }

  onPanFileSelected(event: Event) {
    const input = event.target as HTMLInputElement;
    if (input.files?.length) {
      this.panFile = input.files[0];
    }
  }

  captchaResolved: boolean = false;
  captchaToken: string = '';

  onCaptchaResolved(captchaResponse: string | null): void {
    this.captchaResolved = !!captchaResponse;
    this.captchaToken = captchaResponse ?? '';
  }


  isLoading = false
  message: any
  onSubmit() {
    if (!this.captchaResolved) {
      alert("Check the captcha!");
      return;
    }
    if (this.registerForm.valid && this.aadharFile && this.panFile) {
      const formData = new FormData();
      formData.append('CompanyEmail', this.registerForm.value.companyEmail);
      formData.append('CompanyName', this.registerForm.value.companyName);
      formData.append('CompanyContactNumber', this.registerForm.value.companyContactNumber);
      formData.append('CompanyAddress', this.registerForm.value.companyAddress);
      formData.append('CompanyAccountNumber', this.registerForm.value.companyAccountNumber);
      formData.append('IFSCNumber', this.registerForm.value.ifscNumber);
      formData.append('Password', this.registerForm.value.password);
      formData.append('AadharFile', this.aadharFile);
      formData.append('PanFile', this.panFile);
      this.isLoading = true
      this.authService.doRegistration(formData).subscribe({
        next: (res) => {
          this.message = 'Otp send to your mail';

          const dialogalert = this.dialog.open(AlertBoxMainComponent, {
            width: '500px',
            height: '300px',
            data: this.message
          })

          setTimeout(() => {
            dialogalert.close();
          }, 3000);
          this.isLoading = false
          this.router.navigate(['/register/verify-company'], {
            state: { email: this.registerForm.value.companyEmail }
          });
          this.registerForm.reset();


        },
        error: (err) => {
          console.error('Registration failed:', err);
          this.message = 'Registration failed. Please try again.';
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

      console.log('Form submitted!', formData);
    } else {
      alert('Please fill all fields and upload required documents.');
    }
  }
}
