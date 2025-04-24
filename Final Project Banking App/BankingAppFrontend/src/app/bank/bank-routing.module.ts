import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BankDashboardComponent } from './bank-dashboard/bank-dashboard.component';
import { AuthGuardServiceService } from '../auth-guard-service.service';
import { BankControllerComponent } from './bank-controller/bank-controller.component';
import { GetTransactionBankComponent } from './bank-controller/get-transaction-bank/get-transaction-bank.component';

const routes: Routes = [
  {
    path: '',
    component: BankDashboardComponent,
    canActivate: [AuthGuardServiceService],
    data: { role: 'Bank' },
    children: [
      { path: '', redirectTo: 'bank-controller', pathMatch: 'full' },
      { path: 'bank-controller', component: BankControllerComponent },
      { path: 'get-transaction-bank', component: GetTransactionBankComponent },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BankRoutingModule { }
