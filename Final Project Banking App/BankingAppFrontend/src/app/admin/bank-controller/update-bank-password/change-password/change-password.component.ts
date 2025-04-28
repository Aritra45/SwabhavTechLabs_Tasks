import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AdminServiceService } from '../../../admin-service.service';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-change-password',
  standalone: false,
  templateUrl: './change-password.component.html',
  styleUrl: './change-password.component.css'
})
export class ChangePasswordComponent {
  adminForm!: FormGroup;
  formVisible: boolean = true;

  hidePassword1: boolean = true;
  hidePassword2: boolean = true;
  hidePassword3: boolean = true;

  togglePasswordVisibility1() {
    this.hidePassword1 = !this.hidePassword1;
  }
  togglePasswordVisibility2() {
    this.hidePassword2 = !this.hidePassword2;
  }
  togglePasswordVisibility3() {
    this.hidePassword3 = !this.hidePassword3;
  }

  constructor(@Inject(MAT_DIALOG_DATA) public email: any, private fb: FormBuilder, private http: HttpClient, private adminService: AdminServiceService) {

  }
  ngOnInit() {
    this.adminForm = this.fb.group({
      currentPassword: ['', Validators.required],
      newPassword: ['', [Validators.required, Validators.minLength(6), Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&]).{6,}$')]],
      confirmPassword: ['', Validators.required]
    });
  }


  isLoading = false;
  onSubmit() {
    if (this.adminForm.valid) {
      console.log("Bank email:", this.email);
  
      const formValues = this.adminForm.value; 
      console.log("Form Values:", formValues);
  
      const payload = {
        CurrentPassword: formValues.currentPassword,
        NewPassword: formValues.newPassword,
        ConfirmPassword: formValues.confirmPassword
      };
  
      this.isLoading = true;
      this.adminService.updateBankPassword(this.email, payload).subscribe(
        (res) => {
          this.isLoading = false;
          console.log('Password updated:', res);
          alert('Password updated successfully!');
        },
        (err) => {
          this.isLoading = false;
          console.error('Error updating password:', err);
          alert('Failed to update password.');
        }
      );
    } else {
      console.warn('Form is invalid.');
    }
  }
  
}