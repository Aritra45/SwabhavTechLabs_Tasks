import { AfterViewInit, Component, Inject, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-get-transaction-bank',
  standalone: false,
  templateUrl: './get-transaction-bank.component.html',
  styleUrl: './get-transaction-bank.component.css'
})
export class GetTransactionBankComponent implements AfterViewInit{
  dataSource: MatTableDataSource<any>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  constructor(@Inject(MAT_DIALOG_DATA) public getData: any) {
    this.dataSource = new MatTableDataSource(this.getData);
  }

  displayedColumns: any = ['transactionId', 'transferFromCompanyEmail', 'transferToCompanyEmail', 'paymentDate', 'status'];

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
