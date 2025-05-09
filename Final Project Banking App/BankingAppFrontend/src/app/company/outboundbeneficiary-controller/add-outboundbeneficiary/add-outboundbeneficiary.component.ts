import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { CompanyServiceService } from '../../company-service.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ConfirmBoxComponent } from '../../../confirm-box/confirm-box.component';
import { AlertBoxComponent } from '../../alert-box/alert-box.component';

@Component({
  selector: 'app-add-outboundbeneficiary',
  standalone: false,
  templateUrl: './add-outboundbeneficiary.component.html',
  styleUrl: './add-outboundbeneficiary.component.css'
})
export class AddOutboundbeneficiaryComponent {
  adminForm!: FormGroup;
  formVisible: boolean = true;

  hidePassword: boolean = true;

  togglePasswordVisibility() {
    this.hidePassword = !this.hidePassword;
  }

  constructor(private fb: FormBuilder, private addAdmin: CompanyServiceService, private dialogRef: MatDialogRef<AddOutboundbeneficiaryComponent>, private dialog: MatDialog) {

  }
  ngOnInit() {
    this.adminForm = this.fb.group({
      beneficiaryCompanyEmail: ['', [Validators.required, Validators.email]],
      beneficiaryCompanyName: ['', Validators.required],
      bankAccountNumber: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11)]],
      ifscNumber: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11)]],
    });
  }
  isLoading = false
  message: any
  onSubmit() {
    const dialogR = this.dialog.open(ConfirmBoxComponent);
    dialogR.afterClosed().subscribe(result => {
      if (result) {
        if (this.adminForm.valid) {
          const formData = this.adminForm.value;
          console.log("Form Data: ", formData);
          this.isLoading = true
          this.addAdmin.AddOutBound(formData)
            .subscribe(
              (response) => {
                this.isLoading = false
                console.log("Success:", response);
                alert(response);
                this.message = response;
                const dialogalert = this.dialog.open(AlertBoxComponent, {
                  width: '500px',
                  height: '300px',
                  data: this.message
                })

                setTimeout(() => {
                  dialogalert.close();
                }, 3000);
                this.dialogRef.close()
              },
              (error) => {
                console.error("Error:", error);
                console.error("Error disbursing salary:", error);
                this.message = 'Something went wrong!';
                const dialogalert = this.dialog.open(AlertBoxComponent, {
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
      else {
        this.message = "Task Dismissed!";
        const dialogalert = this.dialog.open(AlertBoxComponent, {
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
