import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { BankServiceService } from '../../bank/bank-service.service';
import { GetInboundbeneficiaryComponent } from './get-inboundbeneficiary/get-inboundbeneficiary.component';
import { CompanyServiceService } from '../company-service.service';
import { AddInboundbeneficiaryComponent } from './add-inboundbeneficiary/add-inboundbeneficiary.component';

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

    add(){
      this.rs.getAllCompany().subscribe(
        (response) => {
          console.log("Companies fetched:", response);
          this.dialog.open(AddInboundbeneficiaryComponent, {
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
