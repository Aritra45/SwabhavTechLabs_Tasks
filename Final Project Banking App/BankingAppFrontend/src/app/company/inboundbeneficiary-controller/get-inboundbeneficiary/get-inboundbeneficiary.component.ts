import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-get-inboundbeneficiary',
  standalone: false,
  templateUrl: './get-inboundbeneficiary.component.html',
  styleUrl: './get-inboundbeneficiary.component.css'
})
export class GetInboundbeneficiaryComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public getData: any) {}

  displayedColumns: any = ['beneficiaryCompanyEmail', 'beneficiaryCompanyName', 'bankAccountNumber', 'iFSCNumber', 'beneficiaryType'];
}
