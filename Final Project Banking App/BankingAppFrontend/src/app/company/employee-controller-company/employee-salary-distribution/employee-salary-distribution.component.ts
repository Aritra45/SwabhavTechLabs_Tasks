import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CompanyServiceService } from '../../company-service.service';
import { HttpHeaders } from '@angular/common/http';
import { jwtDecode } from 'jwt-decode';

@Component({
  selector: 'app-employee-salary-distribution',
  standalone: false,
  templateUrl: './employee-salary-distribution.component.html',
  styleUrl: './employee-salary-distribution.component.css'
})
export class EmployeeSalaryDistributionComponent {
  displayedColumns: any = ['select', 'employeeEmail', 'employeeFullName', 'employeeSalaryAmount'];
  currentMonth: string = new Date().toISOString().slice(0, 7);
  searchText: string = '';

  constructor(
    @Inject(MAT_DIALOG_DATA) public getData: any,
    private rs: CompanyServiceService
  ) { }


  get filteredData() {
    return this.getData.filter((employee: any) =>
      employee.employeeEmail.toLowerCase().includes(this.searchText.toLowerCase()) ||
      employee.employeeFullName.toLowerCase().includes(this.searchText.toLowerCase()) ||
      employee.employeeSalaryAmount.toString().includes(this.searchText)
    );
  }


  isSalaryDisbursed(employee: any): boolean {
    return Array.isArray(employee.salaryDisbursements) &&
      employee.salaryDisbursements.some((disbursement: any) =>
        disbursement.transactionDate.startsWith(this.currentMonth)
      );
  }


  getEligibleEmployees() {
    return this.filteredData.filter((employee: any) =>
      !this.isSalaryDisbursed(employee) && employee.selected
    );
  }


  toggleAll(event: any) {
    const selected = event.checked;
    this.getData.forEach((row: any) => {
      if (!this.isSalaryDisbursed(row)) {
        row.selected = selected;
      }
    });
  }

  isAllSelected(): boolean {
    return this.getData.every((row: any) => row.selected && !this.isSalaryDisbursed(row));
  }

  isIndeterminate(): boolean {
    return this.getData.some((row: any) => row.selected && !this.isSalaryDisbursed(row)) && !this.isAllSelected();
  }


  sendSalary() {
    var con = confirm("Would you like to procced?")
    if (con == true) {
      const selectedEmployees = this.getEligibleEmployees();

      if (selectedEmployees.length === 0) {
        alert('No employees selected or all selected employees have already received salary this month.');
        return;
      }

      const token = localStorage.getItem('token');
      if (!token) {
        alert('No token found!');
        return;
      }

      const decodedToken = jwtDecode(token) as any;
      const companyEmail = decodedToken?.Id;

      if (!companyEmail) {
        alert('Company email is required.');
        return;
      }


      const payload = selectedEmployees.map((emp: any) => ({
        EmployeeEmail: emp.employeeEmail || '',
        CompanyEmail: companyEmail,
        Amount: emp.employeeSalaryAmount,
        Status: 'Pending'
      }));

      const headers = new HttpHeaders({
        'Authorization': `Bearer ${token}`,
        'Content-Type': 'application/json'
      });


      this.rs.addSalaryEmployee(payload, headers).subscribe(
        (response) => {
          console.log("Salary disbursed:", response);
          alert(response.message || 'Salary disbursed successfully!');
        },
        (error) => {
          console.error("Error disbursing salary:", error);

          if (error.error && error.error.errors) {
            console.error("Validation Errors:", error.error.errors);
            alert('Validation Errors:\n' + JSON.stringify(error.error.errors, null, 2));
          } else if (error.error && error.error.title) {
            alert('Error: ' + error.error.title);
          } else {
            alert("Something went wrong while sending salary.");
          }
        }
      );
    }
    else {
      alert("Transaction Dismiss!!!")
    }
  }
}
