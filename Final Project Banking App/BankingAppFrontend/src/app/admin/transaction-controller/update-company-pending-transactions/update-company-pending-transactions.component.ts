import { AfterViewInit, Component, Inject, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { AdminServiceService } from '../../admin-service.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { jwtDecode } from 'jwt-decode';
import { ConfirmBoxComponent } from '../../../confirm-box/confirm-box.component';
import { AlertBoxAdminComponent } from '../../alert-box-admin/alert-box-admin.component';

@Component({
  selector: 'app-update-company-pending-transactions',
  standalone: false,
  templateUrl: './update-company-pending-transactions.component.html',
  styleUrl: './update-company-pending-transactions.component.css'
})
export class UpdateCompanyPendingTransactionsComponent implements AfterViewInit {
  displayedColumns: string[] = ['transactionId', 'transferFromCompanyEmail', 'transferToCompanyEmail', 'transactionAmount', 'paymentDate', 'status', 'action1'];
  adminEmail: any
  payload1: any
  payload2: any
  dataSource: MatTableDataSource<any>;
  constructor(@Inject(MAT_DIALOG_DATA) public getData: any, private updatetransaction: AdminServiceService, private dialog: MatDialog) {
    this.dataSource = new MatTableDataSource(this.getData);

    const token = localStorage.getItem('token')
    if (!token) {
      alert("token not found")
      return
    }
    const decodeToken: any = jwtDecode(token)
    this.adminEmail = decodeToken.Id

    this.payload1 = {
      status: 'Success',
      approvedBy: this.adminEmail
    }
    this.payload2 = {
      status: 'Reject',
      approvedBy: this.adminEmail
    }
  }
  @ViewChild(MatPaginator) paginator!: MatPaginator;


  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  message: any
  rejectTransaction(id: number) {
    const dialogRef = this.dialog.open(ConfirmBoxComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.updatetransaction.updatependingCompanyTransaction(id, this.payload2)
          .subscribe(
            (response) => {
              console.log("Success:", response);

              this.message = 'Transaction updated successfully!';
              const dialogalert = this.dialog.open(AlertBoxAdminComponent, {
                width: '500px',
                height: '300px',
                data: this.message
              })

              setTimeout(() => {
                dialogalert.close();
              }, 3000);

              this.getData = this.getData.filter((transaction: any) => transaction.transactionId !== id);
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

  approveTransaction(id: number) {
    const dialogRef = this.dialog.open(ConfirmBoxComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        console.log(this.payload1)
        this.updatetransaction.updatependingCompanyTransaction(id, this.payload1)
          .subscribe(
            (response) => {
              console.log("Success:", response);
              this.message = 'Transaction updated successfully!';
              const dialogalert = this.dialog.open(AlertBoxAdminComponent, {
                width: '500px',
                height: '300px',
                data: this.message
              })

              setTimeout(() => {
                dialogalert.close();
              }, 3000);

              this.getData = this.getData.filter((transaction: any) => transaction.transactionId !== id);
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

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
