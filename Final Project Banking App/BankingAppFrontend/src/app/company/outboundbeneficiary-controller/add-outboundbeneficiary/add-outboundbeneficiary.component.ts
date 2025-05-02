import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CompanyServiceService } from '../../company-service.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-add-outboundbeneficiary',
  standalone: false,
  templateUrl: './add-outboundbeneficiary.component.html',
  styleUrl: './add-outboundbeneficiary.component.css'
})
export class AddOutboundbeneficiaryComponent {
  adminForm!: FormGroup;
  formVisible: boolean = true;

  hidePassword: boolean = true;

  togglePasswordVisibility() {
    this.hidePassword = !this.hidePassword;
  }

  constructor(private fb: FormBuilder, private http: HttpClient, private addAdmin: CompanyServiceService) {

  }
  ngOnInit() {
    this.adminForm = this.fb.group({
      beneficiaryCompanyEmail: ['', [Validators.required, Validators.email]],
      beneficiaryCompanyName: ['', Validators.required],
      bankAccountNumber: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11)]],
      ifscNumber: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11)]],
    });
  }
  isLoading = false
  onSubmit() {
    const val = confirm("Are You Sure?")
    if (val == true) {
      if (this.adminForm.valid) {
        const formData = this.adminForm.value;
        console.log("Form Data: ", formData);
        this.isLoading = true
        this.addAdmin.AddOutBound(formData)
          .subscribe(
            (response) => {
              this.isLoading = false
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
      alert("Task Dismiss!!!")
    }
  }

}
