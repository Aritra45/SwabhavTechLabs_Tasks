import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AdminServiceService } from '../admin-service.service';
import { UpdateEmployeeSalaryDisburesementComponent } from './update-employee-salary-disburesement/update-employee-salary-disburesement.component';
import { GetUpdatedSalaryComponent } from './get-updated-salary/get-updated-salary.component';
import { jwtDecode } from 'jwt-decode';

@Component({
  selector: 'app-salary-disburesement',
  standalone: false,
  templateUrl: './salary-disburesement.component.html',
  styleUrl: './salary-disburesement.component.css'
})
export class SalaryDisburesementComponent {
  constructor(private dialog: MatDialog, private router: Router, private rs: AdminServiceService) { }

  update() {
    this.rs.getPendingSalary().subscribe(
      (response) => {
        console.log("Salaries fetched:", response);
        this.dialog.open(UpdateEmployeeSalaryDisburesementComponent, {
          maxWidth: '1000px',
          data: response
        });
      },
      (error) => {
        console.error("Error fetching banks:", error);
        alert("Something went wrong");
      }
    )
  }

  getData: any
  get() {
    const token = localStorage.getItem('token')
    if (!token) {
      return
    }
    const decodeToken: any = jwtDecode(token)
    const adminEmail = decodeToken.Id
    this.rs.getUpdatedSalary(adminEmail).subscribe(
      (response) => {
        console.log("Transactions fetched:", response);
        this.dialog.open(GetUpdatedSalaryComponent, {
          width: '1000px',
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
