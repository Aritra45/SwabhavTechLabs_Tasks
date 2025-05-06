import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AdminServiceService } from '../admin-service.service';
import { AddAdminComponent } from './add-admin/add-admin.component';
import { GetAdminComponent } from './get-admin/get-admin.component';
import { RemoveAdminComponent } from './remove-admin/remove-admin.component';
import { jwtDecode } from 'jwt-decode';
import { BlockList } from 'net';

@Component({
  selector: 'app-admin-controller',
  standalone: false,
  templateUrl: './admin-controller.component.html',
  styleUrl: './admin-controller.component.css'
})
export class AdminControllerComponent {
  myrole:any
  show : Boolean = false
  constructor(private dialog: MatDialog, private router:Router, private rs:AdminServiceService) {
    const token = localStorage.getItem('token')
    if (!token) {
      alert("Token not found. Please log in again.");
      return;
    }
    const payload = JSON.parse(atob(token.split('.')[1])); // Decode JWT
    const role = payload['role'] || payload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] || ''
    console.log(role);
    this.myrole = role
    if(this.myrole == "SuperAdmin"){
      this.show = true
    }
    else{
      this.show = false
    }
  }
  

  openAddAdminDialog(){
    
    this.dialog.open(AddAdminComponent, {
      width: '500px'
    });
  }
  
  getData :any
  get() {
    this.rs.getregistration().subscribe(
      (response) => {
        console.log("Admins fetched:", response);
        this.dialog.open(GetAdminComponent, {
          width: '600px',
          data: response
        });
      },
      (error) => {
        console.error("Error fetching admins:", error);
        alert("Something went wrong");
      }
    );
  }
  
  remove(){
    const token = localStorage.getItem('token');
    if (!token) {
      alert("Token not found. Please log in again.");
      return;
    }
    const decodedToken: any = jwtDecode(token);
    const loggedInAdminId = decodedToken.Id;
    this.rs.getregistration().subscribe(
      (response) => {
        const filteredAdmins = response.filter((admin: any) => admin.userEmail !== loggedInAdminId);
        console.log("Admins fetched:", response);
        this.dialog.open(RemoveAdminComponent, {
          width: '90%',
          maxWidth: '700px',
          data: filteredAdmins
        });
      },
      (error) => {
        console.error("Error fetching admins:", error);
        alert("Something went wrong");
      }
    );
  }
}
