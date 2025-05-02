import { AfterViewInit, Component, Inject, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { AdminServiceService } from '../../admin-service.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { ReasonRejectComponent } from '../reason-reject/reason-reject.component';

@Component({
  selector: 'app-update-pending-companies',
  standalone: false,
  templateUrl: './update-pending-companies.component.html',
  styleUrl: './update-pending-companies.component.css'
})
export class UpdatePendingCompaniesComponent implements AfterViewInit {
  displayedColumns: string[] = ['index', 'companyEmail', 'companyName', 'aadharFilePath', 'panFilePath', 'action1'];
  dataSource: MatTableDataSource<any>;
  constructor(@Inject(MAT_DIALOG_DATA) public getData: any, private updateCompany:AdminServiceService, private dialog: MatDialog) {
    this.dataSource = new MatTableDataSource(this.getData);
  }
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  payload1 ={
    isAproved : true,
    remark : "Documents Approved"
  }
  payload2={
    isAproved : false
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }



  rejectCompany(email: string, name: string) {
    this.dialog.open(ReasonRejectComponent, {
      width: '600px',
      height: 'auto',
      data : email
    });
    this.getData = this.getData.filter((admin: any) => admin.companyEmail !== email);
    this.dataSource.data = this.getData;

  }

  approveCompany(email: string, name: string) {
    const val = confirm("Are You Sure?")
    if (val == true) {
    this.updateCompany.updatependingCompany(email, this.payload1)
      .subscribe(
        (response) => {
          console.log(this.payload1);
          console.log("Success:", response);
          alert(`Company ${name} updated successfully.`);

          this.getData = this.getData.filter((admin: any) => admin.companyEmail !== email);
          this.dataSource.data = this.getData;
        },
        (error) => {
          console.error("Error:", error);
          alert(`Error: ${error.message || 'Something went wrong'}`);
        }
      );
    }
    else{
      alert("Task Dismiss!!!")
    }
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
