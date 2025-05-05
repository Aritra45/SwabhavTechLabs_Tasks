import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AdminServiceService } from '../admin-service.service';
import { AddAdminComponent } from './add-admin/add-admin.component';
import { GetAdminComponent } from './get-admin/get-admin.component';
import { RemoveAdminComponent } from './remove-admin/remove-admin.component';
import { jwtDecode } from 'jwt-decode';

@Component({
  selector: 'app-admin-controller',
  standalone: false,
  templateUrl: './admin-controller.component.html',
  styleUrl: './admin-controller.component.css'
})
export class AdminControllerComponent {
  constructor(private dialog: MatDialog, private router:Router, private rs:AdminServiceService) {}

  openAddAdminDialog(){
    console.log("hi");
    
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
