import { HttpClient } from '@angular/common/http';
import { ChangeDetectorRef, Component, ElementRef, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AdminServiceService } from '../../admin-service.service';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { jwtDecode } from 'jwt-decode';
import { AlertBoxComponent } from '../../../company/alert-box/alert-box.component';
import { AlertBoxAdminComponent } from '../../alert-box-admin/alert-box-admin.component';

@Component({
  selector: 'app-add-admin',
  standalone: false,
  templateUrl: './add-admin.component.html',
  styleUrl: './add-admin.component.css'
})
export class AddAdminComponent {
  adminForm!: FormGroup;

  hidePassword: boolean = true;

  togglePasswordVisibility() {
    this.hidePassword = !this.hidePassword;
  }

  constructor(private fb: FormBuilder, private http: HttpClient, private addAdmin: AdminServiceService, private dialogRef: MatDialogRef<AddAdminComponent>, private dialog: MatDialog) {

  }
  ngOnInit() {
    this.adminForm = this.fb.group({
      userEmail: ['', [Validators.required, Validators.email]],
      userName: ['', Validators.required],
      userPassword: ['', [Validators.required, Validators.minLength(6), Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&]).{6,}$')]]
    });
  }
  isLoading = false;
  message: any

  onSubmit() {
    const token = localStorage.getItem('token')
    if (!token) {
      alert('token not found')
      return
    }
    const decodeToken: any = jwtDecode(token)
    const superAdminEmail = decodeToken.Id

    if (this.adminForm.valid) {
      const formData = this.adminForm.value;
      this.isLoading = true;

      this.addAdmin.doRegistration(formData, superAdminEmail)
        .subscribe(
          (response) => {
            this.isLoading = false;
            console.log("Success:", response);
            this.message = response;
            const audio = new Audio('images/successStatus.mp3');
            audio.play();
            const dialogalert = this.dialog.open(AlertBoxAdminComponent, {
              width: '500px',
              height: '300px',
              data: this.message
            })

            setTimeout(() => {
              dialogalert.close();
            }, 3000);
            this.dialogRef.close();

          },
          (error) => {
            this.isLoading = false;
            console.error("Error:", error);
            this.message = 'Something went wrong!';
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
        );
    }
  }



}
