import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-alert-box',
  standalone: false,
  templateUrl: './alert-box.component.html',
  styleUrl: './alert-box.component.css'
})
export class AlertBoxComponent {
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
