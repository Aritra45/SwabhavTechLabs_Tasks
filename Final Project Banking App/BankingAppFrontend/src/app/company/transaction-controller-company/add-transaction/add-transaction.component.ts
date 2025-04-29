import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, Inject, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CompanyServiceService } from '../../company-service.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { SendMoneyComponent } from './send-money/send-money.component';

@Component({
  selector: 'app-add-transaction',
  standalone: false,
  templateUrl: './add-transaction.component.html',
  styleUrl: './add-transaction.component.css'
})
export class AddTransactionComponent implements AfterViewInit{
  dataSource: MatTableDataSource<any>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(@Inject(MAT_DIALOG_DATA) public getData: any, private dialog: MatDialog) {
    const combinedData = [...getData.inbound, ...getData.outbound];  
    this.dataSource = new MatTableDataSource(combinedData);
  }

  displayedColumns: string[] = ['beneficiaryCompanyEmail', 'beneficiaryCompanyName', 'action'];

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  Select(email: any) {
    this.dialog.open(SendMoneyComponent, {
      width: '600px',
      data: email
    });
  }


  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
