import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AdminServiceService } from '../../admin-service.service';

@Component({
  selector: 'app-get-all-audit-userid',
  standalone: false,
  templateUrl: './get-all-audit-userid.component.html',
  styleUrl: './get-all-audit-userid.component.css'
})
export class GetAllAuditUseridComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public getData: any, private adminService: AdminServiceService) {}
  auditData: any;
  displayedColumns: any = ['auditId', 'userId', 'description', 'time'];

  fetchAuditsByUserId(userId: string) {
    this.adminService.getAuditByUserId(userId).subscribe(
      (res) => {
        this.auditData = res;
        console.log('Audits fetched by User ID:', this.auditData);
      },
      (err) => {
        console.error('Error fetching audits by User ID:', err);
      }
    );
  }
  
}
