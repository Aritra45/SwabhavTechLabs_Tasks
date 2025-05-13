import { AfterViewInit, Component, EventEmitter, Inject, Output, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { CompanyServiceService } from '../../company-service.service';
import { HttpHeaders } from '@angular/common/http';
import { jwtDecode } from 'jwt-decode';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { ConfirmBoxComponent } from '../../../confirm-box/confirm-box.component';
import { AlertBoxComponent } from '../../alert-box/alert-box.component';

@Component({
  selector: 'app-employee-salary-distribution',
  standalone: false,
  templateUrl: './employee-salary-distribution.component.html',
  styleUrl: './employee-salary-distribution.component.css'
})
export class EmployeeSalaryDistributionComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  displayedColumns: any = ['select', 'employeeEmail', 'employeeFullName', 'employeeSalaryAmount'];
  currentMonth: string = new Date().toISOString().slice(0, 7);
  searchText: string = '';
  dataSource: MatTableDataSource<any>;
  message: string = '';
  showSuccessAlert: boolean = false;
  constructor(
    @Inject(MAT_DIALOG_DATA) public getData: any,
    private rs: CompanyServiceService,
    private dialogRef: MatDialogRef<EmployeeSalaryDistributionComponent>,
    private dialog: MatDialog,
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
  showAlert = false
  sendSalary() {
    const dialogRef = this.dialog.open(ConfirmBoxComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const selectedEmployees = this.getEligibleEmployees();

        if (selectedEmployees.length === 0) {
          this.showAlert = true
          setTimeout(() => {
            this.showAlert = false;
          }, 5000);
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
          ApprovedBy: ''
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

            this.message = response.message || 'Salary disbursed successfully!';
            const audio = new Audio('images/success.mp3');
            audio.play();
            const dialogalert = this.dialog.open(AlertBoxComponent, {
              width: '500px',
              height: '300px',
              data: this.message
            })

            setTimeout(() => {
              dialogalert.close();
            }, 3000);

            this.dialogRef.close()
          },
          (error) => {
            console.error("Error disbursing salary:", error);
            this.message = 'Something went wrong!';
            const dialogalert = this.dialog.open(AlertBoxComponent, {
              width: '500px',
              height: '300px',
              data: this.message
            })

            setTimeout(() => {
              dialogalert.close();
            }, 3000);
            this.dialogRef.close()
          }
        );
      }
      else {
        this.message = "Transaction Dismissed!";
        const dialogalert = this.dialog.open(AlertBoxComponent, {
          width: '500px',
          height: '300px',
          data: this.message
        })

        setTimeout(() => {
          dialogalert.close();
        }, 3000);

        this.dialogRef.close()
      }
    })
  }


}
