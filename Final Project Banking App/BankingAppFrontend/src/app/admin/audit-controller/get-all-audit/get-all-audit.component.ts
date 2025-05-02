import { AfterViewInit, Component, Inject, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { AdminServiceService } from '../../admin-service.service';

@Component({
  selector: 'app-get-all-audit',
  standalone: false,
  templateUrl: './get-all-audit.component.html',
  styleUrl: './get-all-audit.component.css'
})
export class GetAllAuditComponent implements AfterViewInit {
  displayedColumns: string[] = ['auditId', 'userId', 'description', 'time'];
  dataSource: MatTableDataSource<any>;

  logs: any[] = [];

  totalItems = 0;
  pageSize = 5;
  currentPage = 0;
  searchTerm: string = '';

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(@Inject(MAT_DIALOG_DATA) public getData: any, private adminService: AdminServiceService) {
    this.dataSource = new MatTableDataSource(this.getData);
    this.loadLogs();
  }
  loadLogs() {
    const pageNumber = this.currentPage + 1;
    this.adminService.getAllAudit(pageNumber, this.searchTerm, this.pageSize).subscribe(res => {
      this.logs = res.logs;
      this.totalItems = res.totalItems;
    });
    
  }
  

  onPageChange(event: PageEvent) {
    this.pageSize = event.pageSize;
    this.currentPage = event.pageIndex;
    this.loadLogs();
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }
  onSearchChange(search: string) {
    this.searchTerm = search;
    this.currentPage = 0; // Reset to first page on new search
    this.loadLogs();
  }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  
}
