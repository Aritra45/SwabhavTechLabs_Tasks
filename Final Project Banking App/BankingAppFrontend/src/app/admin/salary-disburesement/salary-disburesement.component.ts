import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AdminServiceService } from '../admin-service.service';
import { UpdateEmployeeSalaryDisburesementComponent } from './update-employee-salary-disburesement/update-employee-salary-disburesement.component';

@Component({
  selector: 'app-salary-disburesement',
  standalone: false,
  templateUrl: './salary-disburesement.component.html',
  styleUrl: './salary-disburesement.component.css'
})
export class SalaryDisburesementComponent {
  constructor(private dialog: MatDialog, private router:Router, private rs:AdminServiceService) {}

  update(){
    this.rs.getPendingSalary().subscribe(
      (response) => {
        console.log("Salaries fetched:", response);
        this.dialog.open(UpdateEmployeeSalaryDisburesementComponent, {
          width: '900px',
          data : response
        });
      },
      (error) => {
        console.error("Error fetching banks:", error);
        alert("Something went wrong");
      }
    )
}
}
