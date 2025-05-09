import { AfterViewInit, Component, Inject, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { AdminServiceService } from '../../admin-service.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { jwtDecode } from 'jwt-decode';
import { ConfirmBoxComponent } from '../../../confirm-box/confirm-box.component';
import { AlertBoxAdminComponent } from '../../alert-box-admin/alert-box-admin.component';

@Component({
  selector: 'app-update-pending-outbound-beneficiary',
  standalone: false,
  templateUrl: './update-pending-outbound-beneficiary.component.html',
  styleUrl: './update-pending-outbound-beneficiary.component.css'
})
export class UpdatePendingOutboundBeneficiaryComponent implements AfterViewInit {
  displayedColumns: string[] = ['beneficiaryCompanyEmail', 'beneficiaryCompanyName', 'companyEmail', 'action1'];
  dataSource: MatTableDataSource<any>;
  payload1: any
  payload2: any
  adminEmail: any
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  constructor(@Inject(MAT_DIALOG_DATA) public getData: any, private updatebeneficiary: AdminServiceService, private dialog: MatDialog) {
    this.dataSource = new MatTableDataSource(this.getData);

    const token = localStorage.getItem('token')
    if (!token) {
      return
    }
    const decodeToken: any = jwtDecode(token)
    this.adminEmail = decodeToken.Id

    this.payload1 = {
      isApproved: true,
      approvedBy: this.adminEmail
    }

    this.payload2 = {
      isApproved: false,
      approvedBy: this.adminEmail
    }
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }


  message: any
  rejectBeneficiary(email: string, name: string) {
    const dialogRef = this.dialog.open(ConfirmBoxComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.updatebeneficiary.updatependingBeneficiaries(email, this.payload2)
          .subscribe(
            (response) => {
              console.log("Success:", response);
              this.message = `Beneficiary ${name} updated successfully`;
              const dialogalert = this.dialog.open(AlertBoxAdminComponent, {
                width: '500px',
                height: '300px',
                data: this.message
              })

              setTimeout(() => {
                dialogalert.close();
              }, 3000);

              this.getData = this.getData.filter((beneficiary: any) => beneficiary.beneficiaryCompanyEmail !== email);
              this.dataSource.data = this.getData;
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
      }

    })
  }

  approveBeneficiary(email: string, name: string) {
    const dialogRef = this.dialog.open(ConfirmBoxComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.updatebeneficiary.updatependingBeneficiaries(email, this.payload1)
          .subscribe(
            (response) => {
              console.log("Success:", response);
              this.message = `Beneficiary ${name} updated successfully`;
              const dialogalert = this.dialog.open(AlertBoxAdminComponent, {
                width: '500px',
                height: '300px',
                data: this.message
              })

              setTimeout(() => {
                dialogalert.close();
              }, 3000);

              this.getData = this.getData.filter((beneficiary: any) => beneficiary.beneficiaryCompanyEmail !== email);
              this.dataSource.data = this.getData;
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
      }
    })
  }
}
