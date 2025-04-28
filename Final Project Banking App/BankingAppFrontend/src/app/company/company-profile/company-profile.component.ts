import { Component } from '@angular/core';
import { CompanyServiceService } from '../company-service.service';
import { jwtDecode } from 'jwt-decode';
import { MatDialog } from '@angular/material/dialog';
import { CheckStatusComponent } from './check-status/check-status.component';

@Component({
  selector: 'app-company-profile',
  standalone: false,
  templateUrl: './company-profile.component.html',
  styleUrl: './company-profile.component.css'
})
export class CompanyProfileComponent {

  constructor(private cs: CompanyServiceService, private dialog: MatDialog) { }

  getData: any
  check() {
    const token = localStorage.getItem('token');

    if (!token) {
      alert("Token not found. Please log in again.");
      return;
    }

    const decodedToken: any = jwtDecode(token);
    console.log(decodedToken)
    const loggedInCompanyId = decodedToken.Id;
    this.cs.getAllCompany().subscribe(
      (res) => {
        const filteredCompanies = res.filter((company: any) => company.companyEmail == loggedInCompanyId);
        this.dialog.open(CheckStatusComponent, {
          width: '600px',
          data: filteredCompanies
        });
      },
      (error) => {
        console.error("Error fetching companies:", error);
        alert("Something went wrong");
      }
    )
  }
}
