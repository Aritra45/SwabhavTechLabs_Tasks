import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-get-outboundbeneficiary',
  standalone: false,
  templateUrl: './get-outboundbeneficiary.component.html',
  styleUrl: './get-outboundbeneficiary.component.css'
})
export class GetOutboundbeneficiaryComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public getData: any) {}

  displayedColumns: any = ['beneficiaryCompanyEmail', 'beneficiaryCompanyName', 'bankAccountNumber', 'iFSCNumber', 'beneficiaryType'];
}
