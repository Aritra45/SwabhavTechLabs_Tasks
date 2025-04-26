import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CompanyServiceService } from '../../company-service.service';

@Component({
  selector: 'app-add-inboundbeneficiary',
  standalone: false,
  templateUrl: './add-inboundbeneficiary.component.html',
  styleUrl: './add-inboundbeneficiary.component.css'
})
export class AddInboundbeneficiaryComponent {
  displayedColumns: string[] = ['companyEmail', 'companyName', 'companyAccountNumber', 'iFSCNumber', 'action'];

  constructor(@Inject(MAT_DIALOG_DATA) public getData: any, private addInbound:CompanyServiceService) {}

  AddInbound(beneficiary: any) {
    const payload = {
      BeneficiaryCompanyEmail: beneficiary.companyEmail,
      BeneficiaryCompanyName: beneficiary.companyName,
      BankAccountNumber: beneficiary.companyAccountNumber,
      IFSCNumber: beneficiary.ifscNumber
    };
    console.log("Payload being sent:", payload);

    this.addInbound.AddInBound(payload)
      .subscribe(
        (response) => {
          console.log("Success:", response);
          alert(`Beneficiary ${beneficiary.companyName} added successfully.`);
          this.getData = this.getData.filter((admin: any) => admin.companyEmail !== beneficiary.companyEmail);
        },
        (error) => {
          console.error("Error:", error);
          alert(`Error: ${error.message || 'Something went wrong'}`);
        }
      );
  }
}

