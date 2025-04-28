import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BankRoutingModule } from './bank-routing.module';
import { BankDashboardComponent } from './bank-dashboard/bank-dashboard.component';
import { BankControllerComponent } from './bank-controller/bank-controller.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { FormsModule } from '@angular/forms';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTableModule } from '@angular/material/table';
import { GetTransactionBankComponent } from './bank-controller/get-transaction-bank/get-transaction-bank.component';
import { MatPaginatorModule } from '@angular/material/paginator';


@NgModule({
  declarations: [
    BankDashboardComponent,
    BankControllerComponent,
    GetTransactionBankComponent,

  ],
  imports: [
    CommonModule,
    BankRoutingModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    FormsModule,
    MatSidenavModule,
    MatToolbarModule,
    MatListModule,
    MatIconModule,
    MatDialogModule,
    MatTableModule,
    MatPaginatorModule
  ]
})
export class BankModule { }
