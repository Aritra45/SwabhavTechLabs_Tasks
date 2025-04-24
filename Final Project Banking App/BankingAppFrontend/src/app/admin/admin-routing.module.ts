import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AuthGuardServiceService } from '../auth-guard-service.service';
import { AdminControllerComponent } from './admin-controller/admin-controller.component';
import { BankControllerComponent } from './bank-controller/bank-controller.component';
import { AddAdminComponent } from './admin-controller/add-admin/add-admin.component';
import { GetAdminComponent } from './admin-controller/get-admin/get-admin.component';
import { RemoveAdminComponent } from './admin-controller/remove-admin/remove-admin.component';
import { GetBankComponent } from './bank-controller/get-bank/get-bank.component';
import { CompanyControllerComponent } from './company-controller/company-controller.component';
import { TransactionControllerComponent } from './transaction-controller/transaction-controller.component';
import { OutboundBeneficiaryControllerComponent } from './outbound-beneficiary-controller/outbound-beneficiary-controller.component';
import { AuditControllerComponent } from './audit-controller/audit-controller.component';

const routes: Routes = [
  {
    path: '',
    component: AdminDashboardComponent,
    canActivate: [AuthGuardServiceService],
    data: { role: 'Admin' },
    children: [
      { path: '', redirectTo: 'admin-controller', pathMatch: 'full' },
      { path: 'admin-controller', component: AdminControllerComponent },
      { path: 'add-admin', component: AddAdminComponent},
      { path: 'get-admin', component: GetAdminComponent},
      { path: 'remove-admin', component: RemoveAdminComponent },
      { path: 'bank-controller', component: BankControllerComponent },
      {path:'get-bank', component:GetBankComponent},
      { path: 'company-controller', component: CompanyControllerComponent },
      { path: 'transaction-controller', component: TransactionControllerComponent },
      { path: 'outbound-beneficiary-controller', component: OutboundBeneficiaryControllerComponent },
      { path: 'audit-controller', component: AuditControllerComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
