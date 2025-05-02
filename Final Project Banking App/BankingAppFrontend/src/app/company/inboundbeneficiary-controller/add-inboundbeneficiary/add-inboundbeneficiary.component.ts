import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, Inject, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CompanyServiceService } from '../../company-service.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-add-inboundbeneficiary',
  standalone: false,
  templateUrl: './add-inboundbeneficiary.component.html',
  styleUrl: './add-inboundbeneficiary.component.css'
})
export class AddInboundbeneficiaryComponent implements AfterViewInit{
  dataSource: MatTableDataSource<any>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  displayedColumns: string[] = ['companyEmail', 'companyName', 'companyAccountNumber', 'iFSCNumber', 'action'];

  constructor(@Inject(MAT_DIALOG_DATA) public getData: any, private addInbound:CompanyServiceService) {
    this.dataSource = new MatTableDataSource(this.getData);
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }
  AddInbound(beneficiary: any) {
    const val = confirm("Are You Sure?")
    if (val == true) {
    const payload = {
      BeneficiaryCompanyEmail: beneficiary.companyEmail,
      BeneficiaryCompanyName: beneficiary.companyName,
      BankAccountNumber: beneficiary.companyAccountNumber,
      IFSCNumber: beneficiary.ifscNumber
    };
    console.log("Payload being sent:", payload);

    this.addInbound.AddInBound(payload)
      .subscribe(
        (response) => {
          console.log("Success:", response);
          alert(response);
          this.getData = this.getData.filter((company: any) => company.companyEmail !== beneficiary.companyEmail);
          this.dataSource.data = this.getData;
        },
        (error) => {
          console.error("Error:", error);
          alert(`Error: ${error.message || 'Something went wrong'}`);
        }
      );
    }
    else{
      alert("Task Dismiss!!!")
    }
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}

