import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AdminServiceService } from '../admin-service.service';
import { UpdatePendingOutboundBeneficiaryComponent } from './update-pending-outbound-beneficiary/update-pending-outbound-beneficiary.component';
import { jwtDecode } from 'jwt-decode';
import { GetUpdatedBeneficiaryComponent } from './get-updated-beneficiary/get-updated-beneficiary.component';

@Component({
  selector: 'app-outbound-beneficiary-controller',
  standalone: false,
  templateUrl: './outbound-beneficiary-controller.component.html',
  styleUrl: './outbound-beneficiary-controller.component.css'
})
export class OutboundBeneficiaryControllerComponent {
  constructor(private dialog: MatDialog, private router: Router, private rs: AdminServiceService) { }

  update() {

    this.rs.getPendingBeneficiaries().subscribe(
      (response) => {
        console.log("Beneficiaries fetched:", response);
        this.dialog.open(UpdatePendingOutboundBeneficiaryComponent, {
          maxWidth: '1000px',
          data: response
        });
      },
      (error) => {
        console.error("Error fetching banks:", error);
        alert("Something went wrong");
      }
    )
  }

  getData: any
  get() {
    const token = localStorage.getItem('token')
    if (!token) {
      return
    }
    const decodeToken: any = jwtDecode(token)
    const adminEmail = decodeToken.Id
    this.rs.getUpdatedBeneficiaries(adminEmail).subscribe(
      (response) => {
        console.log("Beneficiaries fetched:", response);
        this.dialog.open(GetUpdatedBeneficiaryComponent, {
          width: '1000px',
          maxWidth: '1000px',
          data: response
        });
      },
      (error) => {
        console.error("Error fetching Beneficiaries:", error);
        alert("Something went wrong");
      }
    );
  }
}
