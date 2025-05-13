import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { AdminServiceService } from '../../admin-service.service';
import { ConfirmBoxComponent } from '../../../confirm-box/confirm-box.component';
import { AlertBoxComponent } from '../../../company/alert-box/alert-box.component';
import { AlertBoxAdminComponent } from '../../alert-box-admin/alert-box-admin.component';

@Component({
  selector: 'app-remove-admin',
  standalone: false,
  templateUrl: './remove-admin.component.html',
  styleUrl: './remove-admin.component.css'
})
export class RemoveAdminComponent {
  displayedColumns: string[] = ['index', 'userName', 'userEmail', 'action'];

  constructor(@Inject(MAT_DIALOG_DATA) public getData: any, private removeAdmin: AdminServiceService, private dialogRef: MatDialogRef<RemoveAdminComponent>, private dialog: MatDialog) { }
  message: any
  deleteAdmin(email: string, name: string) {
    const dialogRef = this.dialog.open(ConfirmBoxComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.removeAdmin.removeAdminAccess(email)
          .subscribe(
            (response) => {
              console.log("Success:", response);
              this.message = `Admin ${name} removed successfully`;
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

              // Remove the deleted admin from the list
              this.getData = this.getData.filter((admin: any) => admin.userEmail !== email);
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
              this.dialogRef.close()
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
