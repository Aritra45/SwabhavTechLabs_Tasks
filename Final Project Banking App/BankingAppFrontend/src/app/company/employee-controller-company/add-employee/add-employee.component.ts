import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CompanyServiceService } from '../../company-service.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-employee',
  standalone: false,
  templateUrl: './add-employee.component.html',
  styleUrl: './add-employee.component.css'
})
export class AddEmployeeComponent {
  

  adminForm!: FormGroup;
  formVisible: boolean = true;
  selectedFile: File | null = null;

  constructor(private fb: FormBuilder, private http: HttpClient, private addAdmin: CompanyServiceService) {}

  ngOnInit() {
    this.adminForm = this.fb.group({
      file: [''],
    });
  }

  onFileSelected(event: any) {
    const input = event.target as HTMLInputElement;
    if (input.files?.length) {
      this.selectedFile = input.files[0];
    }
  }

  onSubmit() {
    if (this.adminForm.valid && this.selectedFile) {
      const formData = new FormData();
      formData.append('file', this.selectedFile);

      this.addAdmin.AddEmployee(formData)
        .subscribe(
          (response) => {
            console.log('Success:', response);
            alert("Employess Uploaded Successfully!!!"); 
          },
          (error) => {
            console.error('Error:', error);
            alert(`Error: ${error.message || 'Something went wrong'}`);
            console.log('Error Details:', error);
          }
        );
    } else {
      alert('Please select a file.');
    }
  }
  
  

}
