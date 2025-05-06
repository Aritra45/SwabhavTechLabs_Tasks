import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CompanyRoutingModule } from './company-routing.module';
import { CompanyDashboardComponent } from './company-dashboard/company-dashboard.component';

import { MatTableModule } from '@angular/material/table';
import { MatDialogModule } from '@angular/material/dialog';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatDatepickerModule } from '@angular/material/datepicker';

import { MatNativeDateModule, MatPseudoCheckboxModule } from '@angular/material/core';
import { InboundbeneficiaryControllerComponent } from './inboundbeneficiary-controller/inboundbeneficiary-controller.component';
import { GetInboundbeneficiaryComponent } from './inboundbeneficiary-controller/get-inboundbeneficiary/get-inboundbeneficiary.component';
import { AddInboundbeneficiaryComponent } from './inboundbeneficiary-controller/add-inboundbeneficiary/add-inboundbeneficiary.component';
import { GetOutboundbeneficiaryComponent } from './outboundbeneficiary-controller/get-outboundbeneficiary/get-outboundbeneficiary.component';
import { OutboundbeneficiaryControllerComponent } from './outboundbeneficiary-controller/outboundbeneficiary-controller.component';
import { AddOutboundbeneficiaryComponent } from './outboundbeneficiary-controller/add-outboundbeneficiary/add-outboundbeneficiary.component';
import { TransactionControllerCompanyComponent } from './transaction-controller-company/transaction-controller-company.component';
import { AddTransactionComponent } from './transaction-controller-company/add-transaction/add-transaction.component';
import { EmployeeControllerCompanyComponent } from './employee-controller-company/employee-controller-company.component';
import { AddEmployeeComponent } from './employee-controller-company/add-employee/add-employee.component';
import { GetEmployeeComponent } from './employee-controller-company/get-employee/get-employee.component';
import { EmployeeSalaryDistributionComponent } from './employee-controller-company/employee-salary-distribution/employee-salary-distribution.component';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { CompanyProfileComponent } from './company-profile/company-profile.component';
import { CheckStatusComponent } from './company-profile/check-status/check-status.component';
import { SendMoneyComponent } from './transaction-controller-company/add-transaction/send-money/send-money.component';
import { GetTransactionComponent } from './transaction-controller-company/get-transaction/get-transaction.component';
@NgModule({
  declarations: [
    CompanyDashboardComponent,
    InboundbeneficiaryControllerComponent,
    GetInboundbeneficiaryComponent,
    AddInboundbeneficiaryComponent,
    GetOutboundbeneficiaryComponent,
    OutboundbeneficiaryControllerComponent,
    AddOutboundbeneficiaryComponent,
    TransactionControllerCompanyComponent,
    AddTransactionComponent,
    EmployeeControllerCompanyComponent,
    AddEmployeeComponent,
    GetEmployeeComponent,
    EmployeeSalaryDistributionComponent,
    CompanyProfileComponent,
    CheckStatusComponent,
    SendMoneyComponent,
    GetTransactionComponent
  ],
  imports: [
    CommonModule,
    CompanyRoutingModule,
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
    MatDatepickerModule,
    MatNativeDateModule,
    ReactiveFormsModule,
    FormsModule,
    MatCheckboxModule,
    MatPaginatorModule,
    MatProgressSpinnerModule
  ]
})
export class CompanyModule { }
