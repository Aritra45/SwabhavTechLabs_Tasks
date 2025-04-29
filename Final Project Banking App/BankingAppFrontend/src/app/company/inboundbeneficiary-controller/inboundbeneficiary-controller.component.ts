import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { BankServiceService } from '../../bank/bank-service.service';
import { GetInboundbeneficiaryComponent } from './get-inboundbeneficiary/get-inboundbeneficiary.component';
import { CompanyServiceService } from '../company-service.service';
import { AddInboundbeneficiaryComponent } from './add-inboundbeneficiary/add-inboundbeneficiary.component';
import { jwtDecode } from 'jwt-decode';

@Component({
  selector: 'app-inboundbeneficiary-controller',
  standalone: false,
  templateUrl: './inboundbeneficiary-controller.component.html',
  styleUrl: './inboundbeneficiary-controller.component.css'
})
export class InboundbeneficiaryControllerComponent {
  constructor(private dialog: MatDialog, private router: Router, private rs: CompanyServiceService) { }

  getData: any
  get() {
    this.rs.getInBoundBeneficiary().subscribe(
      (response) => {
        console.log("InBoundBeneficiary fetched:", response);
        this.dialog.open(GetInboundbeneficiaryComponent, {
          maxWidth: '1000px',
          data: response
        });
      },
      (error) => {
        console.error("Error fetching admins:", error);
        alert("Something went wrong");
      }
    );
  }

  add() {
    const token = localStorage.getItem('token');
  
    if (!token) {
      alert("Token not found. Please log in again.");
      return;
    }
  
    try {
      const decodedToken: any = jwtDecode(token);
      const loggedInCompanyId = decodedToken.Id;
  
      this.rs.getAllCompany().subscribe(
        (allCompanies) => {
          // Filter out the logged-in company
          const filteredCompanies = allCompanies.filter((company: any) => company.companyEmail !== loggedInCompanyId);
  
          this.rs.getInBoundBeneficiary().subscribe(
            (inboundCompanies) => {
              const inboundEmails = inboundCompanies.map((c: any) => c.beneficiaryCompanyEmail);
              console.log(inboundEmails)
              
              const finalFilteredCompanies = filteredCompanies.filter(
                (company: any) => !inboundEmails.includes(company.companyEmail)
              );
  
              console.log("Filtered companies:", finalFilteredCompanies);
  
              this.dialog.open(AddInboundbeneficiaryComponent, {
                maxWidth: '1000px',
                data: finalFilteredCompanies
              });
            },
            (error) => {
              console.error("Error fetching inbound beneficiary:", error);
              alert("Failed to retrieve inbound beneficiary data.");
            }
          );
        },
        (error) => {
          console.error("Error fetching companies:", error);
          alert("Something went wrong while fetching companies.");
        }
      );
    } catch (error) {
      console.error("Error decoding token:", error);
      alert("Invalid token. Please log in again.");
    }
  }
  
  
}
