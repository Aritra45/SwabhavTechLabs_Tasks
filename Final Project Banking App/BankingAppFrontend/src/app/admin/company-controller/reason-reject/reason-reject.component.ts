import { HttpHeaders } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { jwtDecode } from 'jwt-decode';
import { CompanyServiceService } from '../../../company/company-service.service';
import { AdminServiceService } from '../../admin-service.service';
import { ConfirmBoxComponent } from '../../../confirm-box/confirm-box.component';
import { AlertBoxAdminComponent } from '../../alert-box-admin/alert-box-admin.component';

@Component({
  selector: 'app-reason-reject',
  standalone: false,
  templateUrl: './reason-reject.component.html',
  styleUrl: './reason-reject.component.css'
})
export class ReasonRejectComponent {
  displayedColumns: string[] = ['select', 'reasons'];

  // Data for each row, including rejection reasons for each row
  getData: any[] = [
    { selected: false, reasons: ['Missing Documents'] },
    { selected: false, reasons: ['Expired Documents'] },
    { selected: false, reasons: ['Incomplete Information'] },
    { selected: false, reasons: ['Invalid Format'] },
    { selected: false, reasons: ['Other'] },

  ];

  constructor(@Inject(MAT_DIALOG_DATA) public email: any, private updateCompany: AdminServiceService, private dialogRef: MatDialogRef<ReasonRejectComponent>, private dialog: MatDialog) { }


  toggleAll(event: any) {
    const selected = event.checked;
    this.getData.forEach((row) => {
      row.selected = selected;
    });
  }


  isAllSelected(): boolean {
    return this.getData.every((row) => row.selected);
  }


  isIndeterminate(): boolean {
    return this.getData.some((row) => row.selected) && !this.isAllSelected();
  }

  payload2 = {
    isAproved: false,
    remark: ""
  }

  message: any
  reject() {
    const dialogRef = this.dialog.open(ConfirmBoxComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const selectedReasons = this.getData
          .filter(row => row.selected)
          .map(row => row.reasons[0]);

        const remarkText = selectedReasons.join('. ');


        this.payload2.remark = remarkText;
        this.payload2.isAproved = false;


        this.updateCompany.updatependingCompany(this.email, this.payload2)
          .subscribe(
            (response) => {
              console.log("Success:", response);
              this.message = 'Company Rejected successfully!';
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
              this.dialogRef.close()
            },
            (error) => {
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
            }
          );
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
