import { AfterViewInit, Component, Inject, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CompanyServiceService } from '../../company-service.service';
import { HttpHeaders } from '@angular/common/http';
import { jwtDecode } from 'jwt-decode';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-employee-salary-distribution',
  standalone: false,
  templateUrl: './employee-salary-distribution.component.html',
  styleUrl: './employee-salary-distribution.component.css'
})
export class EmployeeSalaryDistributionComponent implements AfterViewInit{
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  displayedColumns: any = ['select', 'employeeEmail', 'employeeFullName', 'employeeSalaryAmount'];
  currentMonth: string = new Date().toISOString().slice(0, 7);
  searchText: string = '';
  dataSource: MatTableDataSource<any>;

  constructor(
    @Inject(MAT_DIALOG_DATA) public getData: any,
    private rs: CompanyServiceService,
    private dialogRef: MatDialogRef<EmployeeSalaryDistributionComponent>
  ) {
    this.dataSource = new MatTableDataSource(getData);
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  get filteredData() {
    return this.dataSource.filteredData.filter((employee: any) =>
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

  isLoading = false
  sendSalary() {
    var con = confirm("Would you like to proceed?");
    if (con === true) {
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
        Status: 'Pending',
        ApprovedBy : ''
      }));

      const headers = new HttpHeaders({
        'Authorization': `Bearer ${token}`,
        'Content-Type': 'application/json'
      });
      this.isLoading = true
      this.rs.addSalaryEmployee(payload, headers).subscribe(
        (response) => {
          this.isLoading = false
          console.log("Salary disbursed:", response);
          alert(response.message || 'Salary disbursed successfully!');
          this.dialogRef.close()
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
      alert("Transaction Dismissed!");
    }
  }
}
