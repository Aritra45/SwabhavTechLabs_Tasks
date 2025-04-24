import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { AdminServiceService } from '../../admin-service.service';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-get-admin',
  standalone: false,
  templateUrl: './get-admin.component.html',
  styleUrl: './get-admin.component.css'
})
export class GetAdminComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public getData: any) {}

  displayedColumns: any = ['index', 'userName', 'userEmail'];

 
}
