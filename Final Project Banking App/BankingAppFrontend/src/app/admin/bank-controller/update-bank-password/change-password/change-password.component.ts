import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AdminServiceService } from '../../../admin-service.service';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { AlertBoxAdminComponent } from '../../../alert-box-admin/alert-box-admin.component';
import { ConfirmBoxComponent } from '../../../../confirm-box/confirm-box.component';

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

  constructor(@Inject(MAT_DIALOG_DATA) public email: any, private fb: FormBuilder, private http: HttpClient, private adminService: AdminServiceService, private dialogRef: MatDialogRef<ChangePasswordComponent>, private dialog: MatDialog) {

  }
  ngOnInit() {
    this.adminForm = this.fb.group({
      currentPassword: ['', Validators.required],
      newPassword: ['', [Validators.required, Validators.minLength(6), Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&]).{6,}$')]],
      confirmPassword: ['', Validators.required]
    });
  }


  isLoading = false;
  message: any
  onSubmit() {
    const dialogRef = this.dialog.open(ConfirmBoxComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
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
              this.message = 'Password updated successfully!';
              const dialogalert = this.dialog.open(AlertBoxAdminComponent, {
                width: '500px',
                height: '300px',
                data: this.message
              })

              setTimeout(() => {
                dialogalert.close();
              }, 3000);
              this.dialogRef.close()
            },
            (err) => {
              this.isLoading = false;
              console.error('Error updating password:', err);
              this.message = 'Something went wrong!';
              const dialogalert = this.dialog.open(AlertBoxAdminComponent, {
                width: '500px',
                height: '300px',
                data: this.message
              })
              setTimeout(() => {
                dialogalert.close();
              }, 3000);
            }
          );
        } else {
          console.warn('Form is invalid.');
        }
      }
      else {

        this.message = "Task Dismissed!";
        const dialogalert = this.dialog.open(AlertBoxAdminComponent, {
          width: '500px',
          height: '300px',
          data: this.message
        })

        setTimeout(() => {
          dialogalert.close();
        }, 3000);

        this.dialogRef.close()
      }
    })
  }

}