import { Component, Inject, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-check-status',
  standalone: false,
  templateUrl: './check-status.component.html',
  styleUrl: './check-status.component.css'
})
export class CheckStatusComponent {
  
  
  constructor(@Inject(MAT_DIALOG_DATA) public getData: any) {
    
  }

  displayedColumns: any = ['companyEmail', 'remark'];

  splitStatus(status: string): string[] {
    if (!status) {
      return ['Pending'];
    }
    return status
      .split('.')
      .map(s => s.trim())
      .filter(s => s.length > 0);
  }
}
