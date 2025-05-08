import { AfterViewInit, Component, Inject, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AdminServiceService } from '../../admin-service.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { jwtDecode } from 'jwt-decode';

@Component({
  selector: 'app-update-company-pending-transactions',
  standalone: false,
  templateUrl: './update-company-pending-transactions.component.html',
  styleUrl: './update-company-pending-transactions.component.css'
})
export class UpdateCompanyPendingTransactionsComponent implements AfterViewInit {
  displayedColumns: string[] = ['transactionId', 'transferFromCompanyEmail', 'transferToCompanyEmail', 'transactionAmount', 'paymentDate', 'status', 'action1'];
  adminEmail:any
  payload1:any
  payload2:any
  dataSource: MatTableDataSource<any>;
  constructor(@Inject(MAT_DIALOG_DATA) public getData: any, private updatetransaction: AdminServiceService) {
    this.dataSource = new MatTableDataSource(this.getData);

    const token = localStorage.getItem('token')
    if(!token){
      alert ("token not found")
      return
    }
    const decodeToken:any = jwtDecode(token)
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


  rejectTransaction(id: number) {
    const val = confirm("Are You Sure?")
    if (val == true) {
      this.updatetransaction.updatependingCompanyTransaction(id, this.payload2)
        .subscribe(
          (response) => {
            console.log("Success:", response);
            alert(`Transaction updated successfully.`);

            this.getData = this.getData.filter((transaction: any) => transaction.transactionId !== id);
            this.dataSource.data = this.getData;
          },
          (error) => {
            console.error("Error:", error);
            alert(`Error: ${error.message || 'Something went wrong'}`);
          }
        );
    }
    else {
      alert("Task Dismiss!!!")
    }
  }

  approveTransaction(id: number) {
    const val = confirm("Are You Sure?")
    if (val == true) {
      console.log(this.payload1)
      this.updatetransaction.updatependingCompanyTransaction(id, this.payload1)
        .subscribe(
          (response) => {
            console.log("Success:", response);
            alert(`Transaction updated successfully.`);

            this.getData = this.getData.filter((transaction: any) => transaction.transactionId !== id);
            this.dataSource.data = this.getData;
          },
          (error) => {
            console.error("Error:", error);
            alert(`Error: ${error.message || 'Something went wrong'}`);
          }
        );
    }
    else {
      alert("Task Dismiss!!!")
    }
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
