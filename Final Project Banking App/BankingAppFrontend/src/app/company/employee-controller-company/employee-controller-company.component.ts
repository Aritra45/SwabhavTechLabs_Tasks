import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { CompanyServiceService } from '../company-service.service';
import { AddEmployeeComponent } from './add-employee/add-employee.component';
import { GetEmployeeComponent } from './get-employee/get-employee.component';
import { EmployeeSalaryDistributionComponent } from './employee-salary-distribution/employee-salary-distribution.component';

@Component({
  selector: 'app-employee-controller-company',
  standalone: false,
  templateUrl: './employee-controller-company.component.html',
  styleUrl: './employee-controller-company.component.css'
})
export class EmployeeControllerCompanyComponent {
  constructor(private dialog: MatDialog, private router: Router, private rs: CompanyServiceService) { }

  getData: any
  get() {
    this.rs.getEmployee().subscribe(
      (response) => {
        console.log("Employees fetched:", response);
        this.dialog.open(GetEmployeeComponent, {
          width: 'auto',
          data: response
        });
      },
      (error) => {
        console.error("Error fetching admins:", error);
        alert("Something went wrong");
      }
    );
  }

  add() {

    this.dialog.open(AddEmployeeComponent, {
      width: 'auto',
    });

  }

  addSalary() {
    this.rs.getEmployee().subscribe(
      (response) => {
        console.log("Employees fetched:", response);
        this.dialog.open(EmployeeSalaryDistributionComponent, {
          maxWidth: '1000px',
          data: response
        });
      },
      (error) => {
        console.error("Error fetching admins:", error);
        alert("Something went wrong");
      }
    );
  }

}
