import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { CompanyServiceService } from '../../company-service.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AlertBoxComponent } from '../../alert-box/alert-box.component';

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

  constructor(private fb: FormBuilder, private http: HttpClient, private addAdmin: CompanyServiceService, private dialogRef: MatDialogRef<AddEmployeeComponent>, private dialog: MatDialog) { }

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

  message: any
  showAlert = false
  onSubmit() {
    if (this.adminForm.valid && this.selectedFile) {
      const formData = new FormData();
      formData.append('file', this.selectedFile);

      this.addAdmin.AddEmployee(formData)
        .subscribe(
          (response) => {
            console.log('Success:', response);

            this.message = "Employess Uploaded Successfully!!!"
            const audio = new Audio('images/successStatus.mp3');
            audio.play();
            const dialogalert = this.dialog.open(AlertBoxComponent, {
              width: '500px',
              height: '300px',
              data: this.message
            })
            setTimeout(() => {
              dialogalert.close();
            }, 3000);

            this.dialogRef.close()
          },
          (error) => {
            console.error('Error:', error);
            this.message = 'Something went wrong!';
            const dialogalert = this.dialog.open(AlertBoxComponent, {
              width: '500px',
              height: '300px',
              data: this.message
            })

            setTimeout(() => {
              dialogalert.close();
            }, 3000);
            this.dialogRef.close()
          }
        );
    } else {
      this.showAlert = true
      setTimeout(() => {
        this.showAlert = false;
      }, 3000);
    }
  }



}
