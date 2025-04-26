import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CompanyServiceService } from '../../company-service.service';

@Component({
  selector: 'app-add-transaction',
  standalone: false,
  templateUrl: './add-transaction.component.html',
  styleUrl: './add-transaction.component.css'
})
export class AddTransactionComponent {
  adminForm!: FormGroup;
  formVisible: boolean = true;
  constructor(private fb: FormBuilder, private http: HttpClient, private addAdmin:CompanyServiceService) {
    
  }
  ngOnInit(){
    this.adminForm = this.fb.group({
      transferToCompanyEmail: ['', [Validators.required, Validators.email]],
      transactionAmount: ['', Validators.required],
    });
  }

  onSubmit() {
    var value = confirm("Are You Sure?")
    if (this.adminForm.valid && value==true) {
      const formData = this.adminForm.value;
      console.log("Form Data: ", formData);  // Check if data is valid
  
      this.addAdmin.AddTransaction(formData)
        .subscribe(
          (response) => {
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
  
  closeForm() {
    this.adminForm.reset(); 
    this.formVisible = false;     

  }
}
