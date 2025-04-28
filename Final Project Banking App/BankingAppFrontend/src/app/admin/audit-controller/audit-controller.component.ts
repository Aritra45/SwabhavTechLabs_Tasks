import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AdminServiceService } from '../admin-service.service';
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
        height: '600px'
      });
    }

    viewbydate(){
      this.dialog.open(GetAllAuditDateComponent, {
        width: '600px',
        height: '600px'
      });
    }
}
