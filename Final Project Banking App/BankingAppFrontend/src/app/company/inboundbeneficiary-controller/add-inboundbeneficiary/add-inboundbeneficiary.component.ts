import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, Inject, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { CompanyServiceService } from '../../company-service.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { ConfirmBoxComponent } from '../../../confirm-box/confirm-box.component';
import { AlertBoxComponent } from '../../alert-box/alert-box.component';

@Component({
  selector: 'app-add-inboundbeneficiary',
  standalone: false,
  templateUrl: './add-inboundbeneficiary.component.html',
  styleUrl: './add-inboundbeneficiary.component.css'
})
export class AddInboundbeneficiaryComponent implements AfterViewInit {
  dataSource: MatTableDataSource<any>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  displayedColumns: string[] = ['companyEmail', 'companyName', 'companyAccountNumber', 'iFSCNumber', 'action'];

  constructor(@Inject(MAT_DIALOG_DATA) public getData: any, private addInbound: CompanyServiceService, private dialog: MatDialog) {
    this.dataSource = new MatTableDataSource(this.getData);
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  message: any
  AddInbound(beneficiary: any) {
    const dialogRef = this.dialog.open(ConfirmBoxComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
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
              this.message = response;
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
              this.getData = this.getData.filter((company: any) => company.companyEmail !== beneficiary.companyEmail);
              this.dataSource.data = this.getData;
            },
            (error) => {
              console.error("Error:", error);
              this.message = 'Something went wrong!';
              const dialogalert = this.dialog.open(AlertBoxComponent, {
                width: '500px',
                height: '300px',
                data: this.message
              })

              setTimeout(() => {
                dialogalert.close();
              }, 3000);
            }
          );
      }
      else {
        this.message = "Task Dismissed!";
        const dialogalert = this.dialog.open(AlertBoxComponent, {
          width: '500px',
          height: '300px',
          data: this.message
        })

        setTimeout(() => {
          dialogalert.close();
        }, 3000);
      }
    })
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}

