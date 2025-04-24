import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AdminServiceService } from '../admin-service.service';
import { AddAdminComponent } from '../admin-controller/add-admin/add-admin.component';
import { GetAdminComponent } from '../admin-controller/get-admin/get-admin.component';
import { RemoveAdminComponent } from '../admin-controller/remove-admin/remove-admin.component';
import { GetBankComponent } from '../bank-controller/get-bank/get-bank.component';
import { AddBankComponent } from '../bank-controller/add-bank/add-bank.component';
import { RemoveBankComponent } from '../bank-controller/remove-bank/remove-bank.component';
import { GetBankIdComponent } from '../bank-controller/get-bank-id/get-bank-id.component';
import { UpdateBankPasswordComponent } from '../bank-controller/update-bank-password/update-bank-password.component';
import { GetAllAuditComponent } from './get-all-audit/get-all-audit.component';
import { GetAllAuditUseridComponent } from './get-all-audit-userid/get-all-audit-userid.component';
import { GetAllAuditDateComponent } from './get-all-audit-date/get-all-audit-date.component';

@Component({
  selector: 'app-audit-controller',
  standalone: false,
  templateUrl: './audit-controller.component.html',
  styleUrl: './audit-controller.component.css'
})
export class AuditControllerComponent {
  constructor(private dialog: MatDialog, private router:Router, private rs:AdminServiceService) {}
    getData :any
  
    view(){
      this.rs.getAllAudit().subscribe(
        (response) => {
          console.log("Banks fetched:", response);
          this.dialog.open(GetAllAuditComponent, {
            width: 'auto',
            data: response
          });
        },
        (error) => {
          console.error("Error fetching banks:", error);
          alert("Something went wrong");
        }
      );
    }
  
    viewbyid(){
      this.dialog.open(GetAllAuditUseridComponent, {
        width: '600px',
      });
    }

    viewbydate(){
      this.dialog.open(GetAllAuditDateComponent, {
        width: 'auto',
      });
    }
}
