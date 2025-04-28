import { AfterViewInit, Component, Inject, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AdminServiceService } from '../../admin-service.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-get-all-audit-date',
  standalone: false,
  templateUrl: './get-all-audit-date.component.html',
  styleUrl: './get-all-audit-date.component.css'
})
export class GetAllAuditDateComponent implements AfterViewInit{
  displayedColumns: string[] = ['auditId', 'userId', 'description', 'time'];
  dataSource: MatTableDataSource<any> = new MatTableDataSource<any>([]);
  selectedDate: Date | null = null;

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    @Inject(MAT_DIALOG_DATA) public getData: any,
    private adminService: AdminServiceService
  ) {}

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  fetchAuditsByDate(date: Date | null): void {
    if (!date) return;

    this.selectedDate = date;
    const formattedDate = date.toLocaleDateString('en-CA'); // yyyy-MM-dd

    this.adminService.getAuditByDate(formattedDate).subscribe({
      next: (data) => {
        this.dataSource.data = data;  // <-- Just update the .data
        this.paginator.firstPage();   // <-- Reset to page 1
        console.log('Audits fetched by Date:', data);
      },
      error: (error) => {
        console.error('Error fetching audits by date:', error);
      }
    });
  }
}
