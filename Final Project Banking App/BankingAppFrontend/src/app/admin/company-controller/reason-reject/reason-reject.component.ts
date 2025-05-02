import { HttpHeaders } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { jwtDecode } from 'jwt-decode';
import { CompanyServiceService } from '../../../company/company-service.service';
import { AdminServiceService } from '../../admin-service.service';

@Component({
  selector: 'app-reason-reject',
  standalone: false,
  templateUrl: './reason-reject.component.html',
  styleUrl: './reason-reject.component.css'
})
export class ReasonRejectComponent {
  displayedColumns: string[] = ['select', 'reasons'];

  // Data for each row, including rejection reasons for each row
  getData: any[] = [
    { selected: false, reasons: ['Missing Documents'] },
    { selected: false, reasons: ['Expired Documents'] },
    { selected: false, reasons: ['Incomplete Information'] },
    { selected: false, reasons: ['Invalid Format'] },
    { selected: false, reasons: ['Other'] },

  ];

  constructor(@Inject(MAT_DIALOG_DATA) public email: any, private updateCompany: AdminServiceService) { }


  toggleAll(event: any) {
    const selected = event.checked;
    this.getData.forEach((row) => {
      row.selected = selected;
    });
  }


  isAllSelected(): boolean {
    return this.getData.every((row) => row.selected);
  }


  isIndeterminate(): boolean {
    return this.getData.some((row) => row.selected) && !this.isAllSelected();
  }

  payload2 = {
    isAproved: false,
    remark: ""
  }


  reject() {
    const val = confirm("Are You Sure?")
    if (val == true) {
      const selectedReasons = this.getData
        .filter(row => row.selected)
        .map(row => row.reasons[0]);

      const remarkText = selectedReasons.join('. ');


      this.payload2.remark = remarkText;
      this.payload2.isAproved = false;


      this.updateCompany.updatependingCompany(this.email, this.payload2)
        .subscribe(
          (response) => {
            console.log("Success:", response);
            alert(`Company updated successfully.`);
          },
          (error) => {
            console.error("Error:", error);
            alert(`Error: ${error.message || 'Something went wrong'}`);
          }
        );
    }
    else {
      alert("Task Dismiss!!!")
    }
  }

}
