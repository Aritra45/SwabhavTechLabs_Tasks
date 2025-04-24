import { Component, Inject } from '@angular/core';
import { AdminServiceService } from '../../admin-service.service';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-get-bank-id',
  standalone: false,
  templateUrl: './get-bank-id.component.html',
  styleUrl: './get-bank-id.component.css'
})
export class GetBankIdComponent {
  bankData: any;

  constructor(private adminService: AdminServiceService, @Inject(MAT_DIALOG_DATA) public getData: any) {}

  displayedColumns: any = ['index', 'bankName', 'branchCode', 'bankAddress'];

  fetchBankById(bankEmail: string) {
    this.adminService.getBankByEmail(bankEmail).subscribe(
      (res) => {
        this.bankData = res;
        console.log('Bank fetched by Email:', this.bankData);
      },
      (err) => {
        console.error('Error fetching bank by Email:', err);
      }
    );
  }
}
