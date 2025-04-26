import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { CompanyServiceService } from '../company-service.service';
import { AddTransactionComponent } from './add-transaction/add-transaction.component';

@Component({
  selector: 'app-transaction-controller-company',
  standalone: false,
  templateUrl: './transaction-controller-company.component.html',
  styleUrl: './transaction-controller-company.component.css'
})
export class TransactionControllerCompanyComponent {
  constructor(private dialog: MatDialog, private router:Router, private rs:CompanyServiceService) {}

  getData :any
    

    add(){
      
          this.dialog.open(AddTransactionComponent, {
            width: '600px',
          });

        
    }

  }