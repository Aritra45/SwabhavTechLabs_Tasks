import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-get-employee',
  standalone: false,
  templateUrl: './get-employee.component.html',
  styleUrl: './get-employee.component.css'
})
export class GetEmployeeComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public getData: any) {}

  displayedColumns: any = ['employeeEmail', 'employeeFullName', 'employeeSalaryAmount'];
}
