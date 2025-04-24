import { Component, Inject } from '@angular/core';
import { AdminServiceService } from '../admin-service.service';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { UpdatePendingCompaniesComponent } from '../company-controller/update-pending-companies/update-pending-companies.component';
import { UpdateCompanyPendingTransactionsComponent } from './update-company-pending-transactions/update-company-pending-transactions.component';

@Component({
  selector: 'app-transaction-controller',
  standalone: false,
  templateUrl: './transaction-controller.component.html',
  styleUrl: './transaction-controller.component.css'
})
export class TransactionControllerComponent {
  constructor(private dialog: MatDialog, private router:Router, private rs:AdminServiceService) {}

  update(){
    this.rs.getPendingCompaniesTransaction().subscribe(
      (response) => {
        console.log("Transactions fetched:", response);
        this.dialog.open(UpdateCompanyPendingTransactionsComponent, {
          width: '900px',
          data : response
        });
      },
      (error) => {
        console.error("Error fetching banks:", error);
        alert("Something went wrong");
      }
    )
}
}
