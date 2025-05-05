import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { AdminServiceService } from '../../admin-service.service';

@Component({
  selector: 'app-remove-bank',
  standalone: false,
  templateUrl: './remove-bank.component.html',
  styleUrl: './remove-bank.component.css'
})
export class RemoveBankComponent {
  displayedColumns: string[] = ['index', 'bankName', 'bankEmail', 'action'];

  constructor(@Inject(MAT_DIALOG_DATA) public getData: any, private removeBank:AdminServiceService, private dialogRef: MatDialogRef<RemoveBankComponent>) {}

  deleteBank(email: string, name: string) {
    const val = confirm("Are You Sure?")
    if (val == true) {
    console.log(email)
    this.removeBank.removeBankAccess(email)
      .subscribe(
        (response) => {
          console.log("Success:", response);
          alert(`Bank ${name} removed successfully.`);
  
          // Remove the deleted admin from the list
          this.getData = this.getData.filter((bank: any) => bank.bankEmail !== email);
          this.dialogRef.close()
        },
        (error) => {
          console.error("Error:", error);
          alert(`Error: ${error.message || 'Something went wrong'}`);
        }
      );
    }
    else{
      alert("Task Dismiss!!!")
    }
  }
}
