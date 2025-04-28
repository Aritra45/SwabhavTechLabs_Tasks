import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AdminServiceService } from '../../admin-service.service';

@Component({
  selector: 'app-add-admin',
  standalone: false,
  templateUrl: './add-admin.component.html',
  styleUrl: './add-admin.component.css'
})
export class AddAdminComponent {
  adminForm!: FormGroup;
  formVisible: boolean = true;

  hidePassword: boolean = true;

  togglePasswordVisibility() {
    this.hidePassword = !this.hidePassword;
  }
  
  constructor(private fb: FormBuilder, private http: HttpClient, private addAdmin:AdminServiceService) {
    
  }
  ngOnInit(){
    this.adminForm = this.fb.group({
      userEmail: ['', [Validators.required, Validators.email]],
      userName: ['', Validators.required],
      userPassword: ['', [Validators.required, Validators.minLength(6), Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&]).{6,}$')]]
    });
  }
  isLoading = false;
  onSubmit() {
    if (this.adminForm.valid) {
      const formData = this.adminForm.value;
      console.log("Form Data: ", formData);  
      this.isLoading = true;
      this.addAdmin.doRegistration(formData)
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
  
  
}
