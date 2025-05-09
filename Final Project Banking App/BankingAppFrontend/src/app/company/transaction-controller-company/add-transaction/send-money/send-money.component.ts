import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AdminServiceService } from '../../../../admin/admin-service.service';
import { HttpClient } from '@angular/common/http';
import { CompanyServiceService } from '../../../company-service.service';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { AlertBoxComponent } from '../../../alert-box/alert-box.component';
import { ConfirmBoxComponent } from '../../../../confirm-box/confirm-box.component';

@Component({
  selector: 'app-send-money',
  standalone: false,
  templateUrl: './send-money.component.html',
  styleUrl: './send-money.component.css'
})
export class SendMoneyComponent {
  adminForm!: FormGroup;
  formVisible: boolean = true;

  hidePassword: boolean = true;

  togglePasswordVisibility() {
    this.hidePassword = !this.hidePassword;
  }

  constructor(private fb: FormBuilder, @Inject(MAT_DIALOG_DATA) public email: any, private cs: CompanyServiceService, private dialogRef: MatDialogRef<SendMoneyComponent>, private dialog: MatDialog) {

  }
  ngOnInit() {
    this.adminForm = this.fb.group({
      transactionAmount: ['', [Validators.required, Validators.min(1)]],
      transferToCompanyEmail: this.email

    });
  }
  isLoading = false;
  message: any
  onSubmit() {
    const dialogRef = this.dialog.open(ConfirmBoxComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        if (this.adminForm.valid) {
          const formData = this.adminForm.value;
          console.log("Form Data: ", formData);
          this.isLoading = true;

          this.cs.AddTransaction(formData)
            .subscribe(
              (response) => {
                this.isLoading = false;
                console.log("Success:", response);
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
        this.message = "Transaction Dismissed!";
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
