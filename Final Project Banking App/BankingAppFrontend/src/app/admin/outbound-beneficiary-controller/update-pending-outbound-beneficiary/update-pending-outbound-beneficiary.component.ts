import { AfterViewInit, Component, Inject, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AdminServiceService } from '../../admin-service.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-update-pending-outbound-beneficiary',
  standalone: false,
  templateUrl: './update-pending-outbound-beneficiary.component.html',
  styleUrl: './update-pending-outbound-beneficiary.component.css'
})
export class UpdatePendingOutboundBeneficiaryComponent implements AfterViewInit {
  displayedColumns: string[] = ['beneficiaryCompanyEmail', 'beneficiaryCompanyName', 'action1'];
  dataSource: MatTableDataSource<any>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  constructor(@Inject(MAT_DIALOG_DATA) public getData: any, private updatebeneficiary:AdminServiceService) {
    this.dataSource = new MatTableDataSource(this.getData);
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  payload1 ={
    isApproved : true
  }

  payload2={
    isApproved : false
  }

  rejectBeneficiary(email: string, name:string) {
    const val = confirm("Are You Sure?")
    if (val == true) {
    this.updatebeneficiary.updatependingBeneficiaries(email, this.payload2)
      .subscribe(
        (response) => {
          console.log("Success:", response);
          alert(`Beneficiary ${name} updated successfully.`);

          this.getData = this.getData.filter((beneficiary: any) => beneficiary.beneficiaryCompanyEmail !== email);
          this.dataSource.data = this.getData;
        },
        (error) => {
          console.error("Error:", error);
          alert(`Error: ${error.message || 'Something went wrong'}`);
        }
      );
    }
    alert("Task Dismiss!!!")
  }

  approveBeneficiary(email: string, name:string) {
    const val = confirm("Are You Sure?")
    if (val == true) {
    this.updatebeneficiary.updatependingBeneficiaries(email, this.payload1)
      .subscribe(
        (response) => {
          console.log("Success:", response);
          alert(`Beneficiary ${name} updated successfully.`);

          this.getData = this.getData.filter((beneficiary: any) => beneficiary.beneficiaryCompanyEmail !== email);
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
}
