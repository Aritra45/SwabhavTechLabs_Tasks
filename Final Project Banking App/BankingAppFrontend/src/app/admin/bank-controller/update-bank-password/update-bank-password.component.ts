import { Component, Inject } from '@angular/core';
import { AdminServiceService } from '../../admin-service.service';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-update-bank-password',
  standalone: false,
  templateUrl: './update-bank-password.component.html',
  styleUrl: './update-bank-password.component.css'
})
export class UpdateBankPasswordComponent {
 constructor(private adminService: AdminServiceService, @Inject(MAT_DIALOG_DATA) public getData: any){}
 bankData: any;

 displayedColumns: any = ['index', 'bankName', 'branchCode', 'bankAddress'];

 bankEmail!: string;
currentPassword!: string;
newPassword!: string;
confirmPassword!: string;

updatePassword() {
  console.log("Bank email:", this.bankEmail);
  console.log("Current:", this.currentPassword);
  console.log("New:", this.newPassword);
  console.log("Confirm:", this.confirmPassword);

  const payload = {
    currentPassword: this.currentPassword,
    newPassword: this.newPassword,
    confirmPassword: this.confirmPassword
  };

  this.adminService.updateBankPassword(this.bankEmail, payload).subscribe(
    (res) => {
      console.log('Password updated:', res);
      alert('Password updated successfully!');
    },
    (err) => {
      console.error('Error updating password:', err);
      alert('Failed to update password.');
    }
  );
}

}
