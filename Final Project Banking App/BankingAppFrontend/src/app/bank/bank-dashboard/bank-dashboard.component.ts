import { Component } from '@angular/core';

@Component({
  selector: 'app-bank-dashboard',
  standalone: false,
  templateUrl: './bank-dashboard.component.html',
  styleUrl: './bank-dashboard.component.css'
})
export class BankDashboardComponent {
  showAlert = true;

  ngOnInit() {
    // Hide alert after 5 seconds
    setTimeout(() => {
      this.showAlert = false;
    }, 5000); // 5000 ms = 5 seconds
  }
}
