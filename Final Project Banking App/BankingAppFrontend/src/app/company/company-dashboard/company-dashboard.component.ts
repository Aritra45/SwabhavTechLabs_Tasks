import { Component } from '@angular/core';
import { CompanyServiceService } from '../company-service.service';
import { MatDialog } from '@angular/material/dialog';
import { jwtDecode } from 'jwt-decode';
import { response } from 'express';
import { Router } from '@angular/router';

@Component({
  selector: 'app-company-dashboard',
  standalone: false,
  templateUrl: './company-dashboard.component.html',
  styleUrl: './company-dashboard.component.css'
})
export class CompanyDashboardComponent {
  documentStatusColor: string = 'orange';
  constructor(private cs: CompanyServiceService, private dialog: MatDialog, private router:Router) {
    const token = localStorage.getItem('token');

    if (!token) {
      alert("Token not found. Please log in again.");
      return;
    }

    const decodedToken: any = jwtDecode(token);
    const loggedInCompanyId = decodedToken.Id;

    this.cs.getAllCompany().subscribe(
      (res) => {
        const filteredCompanies = res.filter((company: any) => company.companyEmail == loggedInCompanyId);

        if (filteredCompanies.length > 0) {
          const remark = filteredCompanies[0].remark;

          if (remark === "Documents Approved") {
            this.documentStatusColor = 'rgb(0, 255, 8)';
          } else if (remark === "") {
            this.documentStatusColor = 'orange';
          } else {
            this.documentStatusColor = 'red';
          }
        }
      },
      (error) => {
        console.error("Error fetching companies:", error);
        alert("Something went wrong");
      }
    )
  }
  
  checkAndNavigate(path: string) {
    const token = localStorage.getItem('token');
  
    if (!token) {
      alert("Token not found. Please log in again.");
      return;
    }
  
    const decodedToken: any = jwtDecode(token);
    const loggedInCompanyId = decodedToken.Id;
  
    this.cs.getApprovedCompany().subscribe(
      (response) => {
        const emails = response.map((c: any) => c.companyEmail);
        const isApproved = emails.includes(loggedInCompanyId);
  
        if (!isApproved) {
          alert("Your Documents are not approved!!!");
        } else {
          this.router.navigate([`/company-dashboard/${path}`]);
        }
      },
      (error) => {
        console.error("Error fetching approved companies:", error);
        alert("Something went wrong.");
      }
    );
  }
  
}
