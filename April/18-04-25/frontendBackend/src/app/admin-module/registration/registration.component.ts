import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegistrationServiceService } from './registration-service.service';

@Component({
  selector: 'app-registration',
  standalone: false,
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'
})
export class RegistrationComponent {
  form!: FormGroup;

  constructor(private fb: FormBuilder, private rs: RegistrationServiceService, private http: HttpClient) { }

  ngOnInit() {
    this.form = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      confirmedPassword: ['', Validators.required]
    });
    
  }

getData:any

  register() {
    this.rs.doRegistration(this.form.value).subscribe(
      (response) => {
        console.log("Success:", response);
        alert("Registration successful!");
      },
      (error) => {
        console.error("Error:", error);
        alert("Something went wrong");
      }
    );
  }

  get() {
    this.rs.getregistration().subscribe(
      (response) => {
        this.getData=response
        console.log("Success:", response);
        alert("Get Users successful!");
      },
      (error) => {
        console.error("Error:", error);
        alert("Something went wrong");
      }
    );
  }
}
