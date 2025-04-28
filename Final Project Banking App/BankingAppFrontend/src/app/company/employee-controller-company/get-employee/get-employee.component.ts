import { AfterViewInit, Component, Inject, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-get-employee',
  standalone: false,
  templateUrl: './get-employee.component.html',
  styleUrl: './get-employee.component.css'
})
export class GetEmployeeComponent implements AfterViewInit{
  dataSource: MatTableDataSource<any>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  constructor(@Inject(MAT_DIALOG_DATA) public getData: any) {
    this.dataSource = new MatTableDataSource(this.getData);
  }

  displayedColumns: any = ['employeeEmail', 'employeeFullName', 'employeeSalaryAmount'];

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }
}
