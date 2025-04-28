import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyDashboardComponent } from './company-dashboard/company-dashboard.component';
import { AuthGuardServiceService } from '../auth-guard-service.service';
import { InboundbeneficiaryControllerComponent } from './inboundbeneficiary-controller/inboundbeneficiary-controller.component';
import { GetInboundbeneficiaryComponent } from './inboundbeneficiary-controller/get-inboundbeneficiary/get-inboundbeneficiary.component';
import { GetOutboundbeneficiaryComponent } from './outboundbeneficiary-controller/get-outboundbeneficiary/get-outboundbeneficiary.component';
import { AddInboundbeneficiaryComponent } from './inboundbeneficiary-controller/add-inboundbeneficiary/add-inboundbeneficiary.component';

import { AddOutboundbeneficiaryComponent } from './outboundbeneficiary-controller/add-outboundbeneficiary/add-outboundbeneficiary.component';
import { OutboundbeneficiaryControllerComponent } from './outboundbeneficiary-controller/outboundbeneficiary-controller.component';
import { TransactionControllerCompanyComponent } from './transaction-controller-company/transaction-controller-company.component';
import { AddTransactionComponent } from './transaction-controller-company/add-transaction/add-transaction.component';
import { EmployeeControllerCompanyComponent } from './employee-controller-company/employee-controller-company.component';
import { CompanyProfileComponent } from './company-profile/company-profile.component';

const routes: Routes = [
  {
    path: '',
    component: CompanyDashboardComponent,
    canActivate: [AuthGuardServiceService],
    data: { role: 'Company' },
    children: [
      { path: '', redirectTo: 'inboundbeneficiary-controller', pathMatch: 'full' },
      { path: 'inboundbeneficiary-controller', component: InboundbeneficiaryControllerComponent },
      { path: 'get-inboundbeneficiary-company', component: GetInboundbeneficiaryComponent },
      { path: 'add-inboundbeneficiary-company', component: AddInboundbeneficiaryComponent },
      { path: 'outboundbeneficiary-controller-company', component: OutboundbeneficiaryControllerComponent },
      { path: 'get-outboundbeneficiary-company', component: GetOutboundbeneficiaryComponent },
      { path: 'add-outboundbeneficiary-company', component: AddOutboundbeneficiaryComponent },
      { path: 'transaction-controller-company', component: TransactionControllerCompanyComponent },
      { path: 'add-transaction-company', component: AddTransactionComponent },
      { path: 'employee-controller-company', component: EmployeeControllerCompanyComponent },
      { path: 'company-profile', component: CompanyProfileComponent },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CompanyRoutingModule { }
