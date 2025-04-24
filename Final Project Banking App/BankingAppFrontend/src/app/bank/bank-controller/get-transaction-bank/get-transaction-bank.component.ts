import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-get-transaction-bank',
  standalone: false,
  templateUrl: './get-transaction-bank.component.html',
  styleUrl: './get-transaction-bank.component.css'
})
export class GetTransactionBankComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public getData: any) {}

  displayedColumns: any = ['transactionId', 'transferFromCompanyEmail', 'transferToCompanyEmail', 'paymentDate', 'status'];
}
