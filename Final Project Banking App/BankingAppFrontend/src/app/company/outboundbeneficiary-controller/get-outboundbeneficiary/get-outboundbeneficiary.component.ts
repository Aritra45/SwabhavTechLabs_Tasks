import { AfterViewInit, Component, Inject, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-get-outboundbeneficiary',
  standalone: false,
  templateUrl: './get-outboundbeneficiary.component.html',
  styleUrl: './get-outboundbeneficiary.component.css'
})
export class GetOutboundbeneficiaryComponent implements AfterViewInit{
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
