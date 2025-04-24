import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AdminServiceService } from '../../admin-service.service';

@Component({
  selector: 'app-get-all-audit-date',
  standalone: false,
  templateUrl: './get-all-audit-date.component.html',
  styleUrl: './get-all-audit-date.component.css'
})
export class GetAllAuditDateComponent {
  auditData: any[] = [];
  displayedColumns: string[] = ['auditId', 'userId', 'description', 'time'];
  selectedDate: Date | null = null;

  constructor(
    @Inject(MAT_DIALOG_DATA) public getData: any,
    private adminService: AdminServiceService
  ) {}

  fetchAuditsByDate(date: Date | null): void {
    if (!date) return;

    this.selectedDate = date;
    const formattedDate = date.toLocaleDateString('en-CA'); // yyyy-MM-dd

    this.adminService.getAuditByDate(formattedDate).subscribe({
      next: (data) => {
        this.auditData = data;
      },
      error: (error) => {
        console.error("Error fetching audits by date:", error);
      }
    });
  }
}
