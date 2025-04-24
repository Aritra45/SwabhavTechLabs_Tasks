import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-get-bank',
  standalone: false,
  templateUrl: './get-bank.component.html',
  styleUrl: './get-bank.component.css'
})
export class GetBankComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public getData: any) {}
  
  displayedColumns: any = ['index', 'bankName', 'branchCode', 'bankAddress'];
}
