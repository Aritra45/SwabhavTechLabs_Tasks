import { AfterViewInit, Component, Inject, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { AdminServiceService } from '../../admin-service.service';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-update-employee-salary-disburesement',
  standalone: false,
  templateUrl: './update-employee-salary-disburesement.component.html',
  styleUrl: './update-employee-salary-disburesement.component.css'
})
export class UpdateEmployeeSalaryDisburesementComponent implements AfterViewInit{
  displayedColumns: string[] = ['transactionId', 'employeeEmail', 'amount', 'transactionDate','status', 'action1'];
  dataSource: MatTableDataSource<any>;
  constructor(@Inject(MAT_DIALOG_DATA) public getData: any, private updatesalary:AdminServiceService) {
    this.dataSource = new MatTableDataSource(this.getData);
  }
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  payload1 ={
    status : 'Success'
  }
  payload2={
    status : 'Reject'
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  rejectTransaction(id: number) {
    this.updatesalary.updatePendingSalary(id, this.payload2)
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

  approveTransaction(id: number) {
    this.updatesalary.updatePendingSalary(id, this.payload1)
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

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
