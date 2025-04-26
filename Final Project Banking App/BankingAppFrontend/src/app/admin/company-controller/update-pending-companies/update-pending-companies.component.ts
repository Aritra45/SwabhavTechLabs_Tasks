import { AfterViewInit, Component, Inject, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AdminServiceService } from '../../admin-service.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-update-pending-companies',
  standalone: false,
  templateUrl: './update-pending-companies.component.html',
  styleUrl: './update-pending-companies.component.css'
})
export class UpdatePendingCompaniesComponent implements AfterViewInit {
  displayedColumns: string[] = ['index', 'companyEmail', 'companyName', 'aadharFilePath', 'panFilePath', 'action1'];
  dataSource: MatTableDataSource<any>;
  constructor(@Inject(MAT_DIALOG_DATA) public getData: any, private removeAdmin:AdminServiceService) {
    this.dataSource = new MatTableDataSource(this.getData);
  }
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  payload1 ={
    isAproved : true
  }
  payload2={
    isAproved : false
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  rejectCompany(email: string, name: string) {
    this.removeAdmin.updatependingCompany(email, this.payload2)
      .subscribe(
        (response) => {
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

  approveCompany(email: string, name: string) {
    this.removeAdmin.updatependingCompany(email, this.payload1)
      .subscribe(
        (response) => {
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

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
