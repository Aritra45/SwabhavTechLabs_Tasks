import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { CompanyServiceService } from '../company-service.service';
import { GetOutboundbeneficiaryComponent } from './get-outboundbeneficiary/get-outboundbeneficiary.component';
import { AddOutboundbeneficiaryComponent } from './add-outboundbeneficiary/add-outboundbeneficiary.component';

@Component({
  selector: 'app-outboundbeneficiary-controller',
  standalone: false,
  templateUrl: './outboundbeneficiary-controller.component.html',
  styleUrl: './outboundbeneficiary-controller.component.css'
})
export class OutboundbeneficiaryControllerComponent {
  constructor(private dialog: MatDialog, private router:Router, private rs:CompanyServiceService) {}

  getData :any
    get() {
      this.rs.getOutBoundBeneficiary().subscribe(
        (response) => {
          console.log("OutBoundBeneficiary fetched:", response);
          this.dialog.open(GetOutboundbeneficiaryComponent, {
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

    add(){
      this.dialog.open(AddOutboundbeneficiaryComponent, {
        width: '600px',
      });
    }
}
