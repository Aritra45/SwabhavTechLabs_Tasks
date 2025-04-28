import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AdminServiceService } from '../admin-service.service';
import { AddAdminComponent } from '../admin-controller/add-admin/add-admin.component';
import { GetAdminComponent } from '../admin-controller/get-admin/get-admin.component';
import { RemoveAdminComponent } from '../admin-controller/remove-admin/remove-admin.component';
import { UpdateBankPasswordComponent } from '../bank-controller/update-bank-password/update-bank-password.component';
import { UpdatePendingCompaniesComponent } from './update-pending-companies/update-pending-companies.component';

@Component({
  selector: 'app-company-controller',
  standalone: false,
  templateUrl: './company-controller.component.html',
  styleUrl: './company-controller.component.css'
})
export class CompanyControllerComponent {
  constructor(private dialog: MatDialog, private router:Router, private rs:AdminServiceService) {}

  update(){
    this.rs.getPendingCompanies().subscribe(
      (response) => {
        console.log("Companies fetched:", response);
        this.dialog.open(UpdatePendingCompaniesComponent, {
          maxWidth: '1000px',
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



// this.rs.getbanks().subscribe(
//       (response) => {
//         console.log("Banks fetched:", response);
//         this.dialog.open(RemoveBankComponent, {
//           width: '90%',
//           maxWidth: '700px',
//           data: response
//         });
//       },
//       (error) => {
//         console.error("Error fetching banks:", error);
//         alert("Something went wrong");
//       }
//     );
