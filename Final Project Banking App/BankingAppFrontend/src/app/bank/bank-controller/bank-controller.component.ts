import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AdminServiceService } from '../../admin/admin-service.service';
import { GetAdminComponent } from '../../admin/admin-controller/get-admin/get-admin.component';
import { BankServiceService } from '../bank-service.service';
import { GetTransactionBankComponent } from './get-transaction-bank/get-transaction-bank.component';

@Component({
  selector: 'app-bank-controller',
  standalone: false,
  templateUrl: './bank-controller.component.html',
  styleUrl: './bank-controller.component.css'
})
export class BankControllerComponent {
  constructor(private dialog: MatDialog, private router:Router, private rs:BankServiceService) {}

  getData :any
    get() {
      this.rs.getTransactions().subscribe(
        (response) => {
          console.log("Transactions fetched:", response);
          this.dialog.open(GetTransactionBankComponent, {
            width: '600px',
            data: response
          });
        },
        (error) => {
          console.error("Error fetching admins:", error);
          alert("Something went wrong");
        }
      );
    }
}
