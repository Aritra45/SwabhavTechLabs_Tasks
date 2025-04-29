import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AdminServiceService } from '../../../../admin/admin-service.service';
import { HttpClient } from '@angular/common/http';
import { CompanyServiceService } from '../../../company-service.service';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-send-money',
  standalone: false,
  templateUrl: './send-money.component.html',
  styleUrl: './send-money.component.css'
})
export class SendMoneyComponent {
  adminForm!: FormGroup;
  formVisible: boolean = true;

  hidePassword: boolean = true;

  togglePasswordVisibility() {
    this.hidePassword = !this.hidePassword;
  }

  constructor(private fb: FormBuilder, @Inject(MAT_DIALOG_DATA) public email: any, private cs: CompanyServiceService) {

  }
  ngOnInit() {
    this.adminForm = this.fb.group({
      transactionAmount: ['', [Validators.required, Validators.min(1)]],
      transferToCompanyEmail: this.email

    });
  }
  isLoading = false;
  onSubmit() {
    const val = confirm("Are Youe Sure?")
    if (val == true) {
      if (this.adminForm.valid) {
        const formData = this.adminForm.value;
        console.log("Form Data: ", formData);
        this.isLoading = true;

        this.cs.AddTransaction(formData)
          .subscribe(
            (response) => {
              this.isLoading = false;
              console.log("Success:", response);
              alert(response);
            },
            (error) => {
              console.error("Error:", error);
              alert(`Error: ${error.message || 'Something went wrong'}`);
              console.log('Error Details:', error);
            }
          );
      }
    }
    else {
      alert("Transaction Dismiss")
    }
  }

}
