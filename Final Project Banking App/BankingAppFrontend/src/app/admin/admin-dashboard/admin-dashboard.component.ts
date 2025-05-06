import { Component } from '@angular/core';

@Component({
  selector: 'app-admin-dashboard',
  standalone: false,
  templateUrl: './admin-dashboard.component.html',
  styleUrl: './admin-dashboard.component.css'
})
export class AdminDashboardComponent {
  myrole:any
  show : Boolean = false

  constructor() {
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
}
