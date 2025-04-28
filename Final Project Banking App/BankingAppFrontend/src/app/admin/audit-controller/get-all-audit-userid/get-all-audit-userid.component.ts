import { AfterViewInit, Component, Inject, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AdminServiceService } from '../../admin-service.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-get-all-audit-userid',
  standalone: false,
  templateUrl: './get-all-audit-userid.component.html',
  styleUrl: './get-all-audit-userid.component.css'
})
export class GetAllAuditUseridComponent implements AfterViewInit {
  
  displayedColumns: string[] = ['auditId', 'userId', 'description', 'time'];
  dataSource: MatTableDataSource<any> = new MatTableDataSource<any>([]);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    @Inject(MAT_DIALOG_DATA) public getData: any,
    private adminService: AdminServiceService
  ) {}

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  fetchAuditsByUserId(userId: string) {
    if (!userId.trim()) return;
    this.adminService.getAuditByUserId(userId).subscribe(
      (res) => {
        this.dataSource.data = res; // <-- Only update data, don't recreate MatTableDataSource
        this.paginator.firstPage();  // <-- Reset to page 1
        console.log('Audits fetched by User ID:', res);
      },
      (err) => {
        console.error('Error fetching audits by User ID:', err);
      }
    );
  }
}
