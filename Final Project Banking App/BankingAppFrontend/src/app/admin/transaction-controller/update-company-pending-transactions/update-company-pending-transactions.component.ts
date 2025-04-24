import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AdminServiceService } from '../../admin-service.service';

@Component({
  selector: 'app-update-company-pending-transactions',
  standalone: false,
  templateUrl: './update-company-pending-transactions.component.html',
  styleUrl: './update-company-pending-transactions.component.css'
})
export class UpdateCompanyPendingTransactionsComponent {
  displayedColumns: string[] = ['transactionId', 'transferFromCompanyEmail', 'transferToCompanyEmail', 'transactionAmount', 'paymentDate','status', 'action1'];

  constructor(@Inject(MAT_DIALOG_DATA) public getData: any, private updatetransaction:AdminServiceService) {}

  payload1 ={
    status : 'Success'
  }
  payload2={
    status : 'Reject'
  }

  rejectTransaction(id: number) {
    this.updatetransaction.updatependingCompanyTransaction(id, this.payload2)
      .subscribe(
        (response) => {
          console.log("Success:", response);
          alert(`Transaction updated successfully.`);

          this.getData = this.getData.filter((transaction: any) => transaction.transactionId !== id);
        },
        (error) => {
          console.error("Error:", error);
          alert(`Error: ${error.message || 'Something went wrong'}`);
        }
      );
  }

  approveTransaction(id: number) {
    this.updatetransaction.updatependingCompanyTransaction(id, this.payload1)
      .subscribe(
        (response) => {
          console.log("Success:", response);
          alert(`Transaction updated successfully.`);

          this.getData = this.getData.filter((transaction: any) => transaction.transactionId !== id);
        },
        (error) => {
          console.error("Error:", error);
          alert(`Error: ${error.message || 'Something went wrong'}`);
        }
      );
  }
}
