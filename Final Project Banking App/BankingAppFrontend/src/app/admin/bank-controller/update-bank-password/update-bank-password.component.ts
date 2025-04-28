import { Component, Inject, ViewChild } from '@angular/core';
import { AdminServiceService } from '../../admin-service.service';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { ChangePasswordComponent } from './change-password/change-password.component';

@Component({
  selector: 'app-update-bank-password',
  standalone: false,
  templateUrl: './update-bank-password.component.html',
  styleUrl: './update-bank-password.component.css'
})
export class UpdateBankPasswordComponent {
//  constructor(private adminService: AdminServiceService, @Inject(MAT_DIALOG_DATA) public getData: any){}
//  bankData: any;

//  displayedColumns: any = ['index', 'bankName', 'branchCode', 'bankAddress'];

//  bankEmail!: string;
// currentPassword!: string;
// newPassword!: string;
// confirmPassword!: string;

// updatePassword() {
//   console.log("Bank email:", this.bankEmail);
//   console.log("Current:", this.currentPassword);
//   console.log("New:", this.newPassword);
//   console.log("Confirm:", this.confirmPassword);

//   const payload = {
//     currentPassword: this.currentPassword,
//     newPassword: this.newPassword,
//     confirmPassword: this.confirmPassword
//   };

//   this.adminService.updateBankPassword(this.bankEmail, payload).subscribe(
//     (res) => {
//       console.log('Password updated:', res);
//       alert('Password updated successfully!');
//     },
//     (err) => {
//       console.error('Error updating password:', err);
//       alert('Failed to update password.');
//     }
//   );
// }

displayedColumns: string[] = ['bankEmail', 'bankName', 'action1'];
  dataSource: MatTableDataSource<any>;
  constructor(@Inject(MAT_DIALOG_DATA) public getData: any, private updateCompany:AdminServiceService, private dialog: MatDialog) {
    this.dataSource = new MatTableDataSource(this.getData);
  }
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  payload1 ={
    isAproved : true,
    remark : "Documents Approved"
  }
  payload2={
    isAproved : false
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }



  updatePassword(email: string) {
    this.dialog.open(ChangePasswordComponent, {
      width: '1000px',
      data : email
    });
    this.getData = this.getData.filter((admin: any) => admin.companyEmail !== email);
    this.dataSource.data = this.getData;

  }

  

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

}
