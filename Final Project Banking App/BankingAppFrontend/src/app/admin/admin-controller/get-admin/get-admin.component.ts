import { AfterViewInit, Component, Inject, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { AdminServiceService } from '../../admin-service.service';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-get-admin',
  standalone: false,
  templateUrl: './get-admin.component.html',
  styleUrl: './get-admin.component.css'
})
export class GetAdminComponent implements AfterViewInit{
  constructor(@Inject(MAT_DIALOG_DATA) public getData: any) {
    this.dataSource = new MatTableDataSource(this.getData);
  }

  displayedColumns: any = ['index', 'userName', 'userEmail'];
  dataSource: MatTableDataSource<any>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
 
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
