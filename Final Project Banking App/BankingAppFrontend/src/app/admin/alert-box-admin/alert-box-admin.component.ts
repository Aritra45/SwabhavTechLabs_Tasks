import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-alert-box-admin',
  standalone: false,
  templateUrl: './alert-box-admin.component.html',
  styleUrl: './alert-box-admin.component.css'
})
export class AlertBoxAdminComponent {
  successMessage:any;
  showSuccessAlert = false;
  constructor(@Inject(MAT_DIALOG_DATA) public getData: any) {
    this.successMessage = getData
    this.showSuccessAlert = true;
    // Hide alert after 5 seconds
    setTimeout(() => {
      this.showSuccessAlert = false;
    }, 5000);
  }

  successGif = "images/successGif.gif"
  errorGif = "images/error.jpeg"
}
