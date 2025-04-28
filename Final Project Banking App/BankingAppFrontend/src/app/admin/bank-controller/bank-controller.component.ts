import { Component } from '@angular/core';
import { GetBankComponent } from './get-bank/get-bank.component';
import { MatDialog } from '@angular/material/dialog';
import { AdminServiceService } from '../admin-service.service';
import { Router } from '@angular/router';
import { AddBankComponent } from './add-bank/add-bank.component';
import { RemoveBankComponent } from './remove-bank/remove-bank.component';
import { GetBankIdComponent } from './get-bank-id/get-bank-id.component';
import { UpdateBankPasswordComponent } from './update-bank-password/update-bank-password.component';

@Component({
  selector: 'app-bank-controller',
  standalone: false,
  templateUrl: './bank-controller.component.html',
  styleUrl: './bank-controller.component.css'
})
export class BankControllerComponent {
  constructor(private dialog: MatDialog, private router: Router, private rs: AdminServiceService) { }
  getData: any

  view() {
    this.rs.getbanks().subscribe(
      (response) => {
        console.log("Banks fetched:", response);
        this.dialog.open(GetBankComponent, {
          width: '600px',
          data: response
        });
      },
      (error) => {
        console.error("Error fetching banks:", error);
        alert("Something went wrong");
      }
    );
  }

  Add(): void {
    this.dialog.open(AddBankComponent, {
      width: '500px'
    });
  }


  remove() {
    this.rs.getbanks().subscribe(
      (response) => {
        console.log("Banks fetched:", response);
        this.dialog.open(RemoveBankComponent, {
          width: '90%',
          maxWidth: '700px',
          data: response
        });
      },
      (error) => {
        console.error("Error fetching banks:", error);
        alert("Something went wrong");
      }
    );
  }

  id() {

    this.dialog.open(GetBankIdComponent, {
      width: '600px',
    });
  }

  update() {
    this.rs.getbanks().subscribe(
      (response) => {
        console.log("Banks fetched:", response);
        this.dialog.open(UpdateBankPasswordComponent, {
          maxWidth: '1000px',
          data: response
        });
      },
      (error) => {
        console.error("Error fetching banks:", error);
        alert("Something went wrong");
      }
    );
  }
}
