import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AdminServiceService } from '../../admin-service.service';

@Component({
  selector: 'app-add-bank',
  standalone: false,
  templateUrl: './add-bank.component.html',
  styleUrl: './add-bank.component.css'
})
export class AddBankComponent {
  adminForm!: FormGroup;
  formVisible: boolean = true;
  constructor(private fb: FormBuilder, private http: HttpClient, private addAdmin:AdminServiceService) {
    
  }
  ngOnInit(){
    this.adminForm = this.fb.group({
      bankEmail: ['', [Validators.required, Validators.email]],
      bankName: ['', Validators.required],
      bankPassword: ['', [Validators.required, Validators.minLength(6), Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&]).{6,}$')]],
      branchCode: ['', Validators.required],
      bankAddress: ['', Validators.required]
    });
  }

  hidePassword: boolean = true;

  togglePasswordVisibility() {
    this.hidePassword = !this.hidePassword;
  }
  isLoading=false
  onSubmit() {
    if (this.adminForm.valid) {
      const formData = this.adminForm.value;
      console.log("Form Data: ", formData);  // Check if data is valid
      this.isLoading=true
      this.addAdmin.doBankRegistration(formData)
        .subscribe(
          (response) => {
            this.isLoading=false
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
  
  
}
