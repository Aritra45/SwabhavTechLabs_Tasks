import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-get-all-audit',
  standalone: false,
  templateUrl: './get-all-audit.component.html',
  styleUrl: './get-all-audit.component.css'
})
export class GetAllAuditComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public getData: any) {}
  
  displayedColumns: any = ['auditId', 'userId', 'description', 'time'];
}
