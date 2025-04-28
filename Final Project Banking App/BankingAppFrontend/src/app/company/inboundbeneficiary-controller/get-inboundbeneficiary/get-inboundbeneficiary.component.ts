import { AfterViewInit, Component, Inject, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-get-inboundbeneficiary',
  standalone: false,
  templateUrl: './get-inboundbeneficiary.component.html',
  styleUrl: './get-inboundbeneficiary.component.css'
})
export class GetInboundbeneficiaryComponent implements AfterViewInit{
  dataSource: MatTableDataSource<any>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  constructor(@Inject(MAT_DIALOG_DATA) public getData: any) {
    this.dataSource = new MatTableDataSource(this.getData);
  }

  displayedColumns: any = ['beneficiaryCompanyEmail', 'beneficiaryCompanyName', 'bankAccountNumber', 'iFSCNumber', 'beneficiaryType'];
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }
}
