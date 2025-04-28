import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { BankServiceService } from '../../bank/bank-service.service';
import { GetInboundbeneficiaryComponent } from './get-inboundbeneficiary/get-inboundbeneficiary.component';
import { CompanyServiceService } from '../company-service.service';
import { AddInboundbeneficiaryComponent } from './add-inboundbeneficiary/add-inboundbeneficiary.component';
import {jwtDecode} from 'jwt-decode';

@Component({
  selector: 'app-inboundbeneficiary-controller',
  standalone: false,
  templateUrl: './inboundbeneficiary-controller.component.html',
  styleUrl: './inboundbeneficiary-controller.component.css'
})
export class InboundbeneficiaryControllerComponent {
  constructor(private dialog: MatDialog, private router:Router, private rs:CompanyServiceService) {}

  getData :any
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
        const decodedToken:any = jwtDecode(token);
        console.log(decodedToken)
        const loggedInCompanyId = decodedToken.Id; 
        
        this.rs.getAllCompany().subscribe(
          (response) => {
            const filteredCompanies = response.filter((company:any) => company.companyEmail !== loggedInCompanyId);
    
            console.log("Filtered companies:", filteredCompanies);
            this.dialog.open(AddInboundbeneficiaryComponent, {
              maxWidth: '1000px',
              data: filteredCompanies
            });
          },
          (error) => {
            console.error("Error fetching companies:", error);
            alert("Something went wrong");
          }
        );
      } catch (error) {
        console.error("Error decoding token:", error);
        alert("Invalid token. Please log in again.");
      }
    }
}
