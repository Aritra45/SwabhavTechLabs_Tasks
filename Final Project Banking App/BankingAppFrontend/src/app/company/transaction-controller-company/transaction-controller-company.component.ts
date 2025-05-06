import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { CompanyServiceService } from '../company-service.service';
import { AddTransactionComponent } from './add-transaction/add-transaction.component';
import { GetTransactionComponent } from './get-transaction/get-transaction.component';
import { jwtDecode } from 'jwt-decode';

@Component({
  selector: 'app-transaction-controller-company',
  standalone: false,
  templateUrl: './transaction-controller-company.component.html',
  styleUrl: './transaction-controller-company.component.css'
})
export class TransactionControllerCompanyComponent {
  constructor(private dialog: MatDialog, private router: Router, private rs: CompanyServiceService) { }

  getData: any


  add() {
    this.rs.getInBoundBeneficiary().subscribe(
      (inBoundRes) => {
        this.rs.getOutBoundBeneficiary().subscribe(
          (outBoundRes) => {
            // Combine inbound and outbound data into one array (or object, if necessary)
            this.getData = {
              inbound: inBoundRes,
              outbound: outBoundRes
            };

            console.log("Combined data:", this.getData);

            // Open dialog with combined data
            this.dialog.open(AddTransactionComponent, {
              width: '600px',
              data: this.getData
            });
          },
          (error) => {
            console.error("Error fetching outbound data:", error);
            alert("Failed to fetch outbound beneficiaries.");
          }
        );
      },
      (error) => {
        console.error("Error fetching inbound data:", error);
        alert("Failed to fetch inbound beneficiaries.");
      }
    );
  }

  get() {
    const token = localStorage.getItem('token');

    if (!token) {
      alert("Token not found. Please log in again.");
      return;
    }
    const decodedToken: any = jwtDecode(token);
    const companyEmail = decodedToken.Id;

    this.rs.getCompanyTransactions(companyEmail).subscribe(
      (response) => {
        console.log("Transactions fetched:", response);
        this.dialog.open(GetTransactionComponent, {
          width: '600px',
          data : response
        });
      },
      (error) => {
        console.error("Error fetching admins:", error);
        alert("Something went wrong");
      }
    );
  }

}