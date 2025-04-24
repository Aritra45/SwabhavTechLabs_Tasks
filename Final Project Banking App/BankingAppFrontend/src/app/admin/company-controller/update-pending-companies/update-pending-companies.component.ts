import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AdminServiceService } from '../../admin-service.service';

@Component({
  selector: 'app-update-pending-companies',
  standalone: false,
  templateUrl: './update-pending-companies.component.html',
  styleUrl: './update-pending-companies.component.css'
})
export class UpdatePendingCompaniesComponent {
  displayedColumns: string[] = ['index', 'companyEmail', 'companyName', 'aadharFilePath', 'panFilePath', 'action1'];

  constructor(@Inject(MAT_DIALOG_DATA) public getData: any, private removeAdmin:AdminServiceService) {}

  payload1 ={
    isAproved : true
  }
  payload2={
    isAproved : false
  }

  rejectCompany(email: string, name: string) {
    this.removeAdmin.updatependingCompany(email, this.payload2)
      .subscribe(
        (response) => {
          console.log("Success:", response);
          alert(`Company ${name} updated successfully.`);

          this.getData = this.getData.filter((admin: any) => admin.companyEmail !== email);
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
        },
        (error) => {
          console.error("Error:", error);
          alert(`Error: ${error.message || 'Something went wrong'}`);
        }
      );
  }
}
