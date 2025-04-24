import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AdminServiceService } from '../../admin-service.service';

@Component({
  selector: 'app-update-pending-outbound-beneficiary',
  standalone: false,
  templateUrl: './update-pending-outbound-beneficiary.component.html',
  styleUrl: './update-pending-outbound-beneficiary.component.css'
})
export class UpdatePendingOutboundBeneficiaryComponent {
  displayedColumns: string[] = ['beneficiaryCompanyEmail', 'beneficiaryCompanyName', 'action1'];

  constructor(@Inject(MAT_DIALOG_DATA) public getData: any, private updatebeneficiary:AdminServiceService) {}

  payload1 ={
    isApproved : true
  }

  payload2={
    isApproved : false
  }

  rejectBeneficiary(email: string, name:string) {
    this.updatebeneficiary.updatependingBeneficiaries(email, this.payload2)
      .subscribe(
        (response) => {
          console.log("Success:", response);
          alert(`Beneficiary ${name} updated successfully.`);

          this.getData = this.getData.filter((beneficiary: any) => beneficiary.beneficiaryCompanyEmail !== email);
        },
        (error) => {
          console.error("Error:", error);
          alert(`Error: ${error.message || 'Something went wrong'}`);
        }
      );
  }

  approveBeneficiary(email: string, name:string) {
    this.updatebeneficiary.updatependingBeneficiaries(email, this.payload1)
      .subscribe(
        (response) => {
          console.log("Success:", response);
          alert(`Beneficiary ${name} updated successfully.`);

          this.getData = this.getData.filter((beneficiary: any) => beneficiary.beneficiaryCompanyEmail !== email);
        },
        (error) => {
          console.error("Error:", error);
          alert(`Error: ${error.message || 'Something went wrong'}`);
        }
      );
  }
}
