import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminControllerComponent } from './admin-controller/admin-controller.component';
import { BankControllerComponent } from './bank-controller/bank-controller.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
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
import { AddAdminComponent } from './admin-controller/add-admin/add-admin.component';
import { GetAdminComponent } from './admin-controller/get-admin/get-admin.component';
import { RemoveAdminComponent } from './admin-controller/remove-admin/remove-admin.component';
import { LogoutComponent } from './logout/logout.component';
import { GetBankComponent } from './bank-controller/get-bank/get-bank.component';
import { AddBankComponent } from './bank-controller/add-bank/add-bank.component';
import { RemoveBankComponent } from './bank-controller/remove-bank/remove-bank.component';
import { GetBankIdComponent } from './bank-controller/get-bank-id/get-bank-id.component';
import { UpdateBankPasswordComponent } from './bank-controller/update-bank-password/update-bank-password.component';
import { CompanyControllerComponent } from './company-controller/company-controller.component';
import { UpdatePendingCompaniesComponent } from './company-controller/update-pending-companies/update-pending-companies.component';
import { TransactionControllerComponent } from './transaction-controller/transaction-controller.component';
import { UpdateCompanyPendingTransactionsComponent } from './transaction-controller/update-company-pending-transactions/update-company-pending-transactions.component';
import { OutboundBeneficiaryControllerComponent } from './outbound-beneficiary-controller/outbound-beneficiary-controller.component';
import { UpdatePendingOutboundBeneficiaryComponent } from './outbound-beneficiary-controller/update-pending-outbound-beneficiary/update-pending-outbound-beneficiary.component';
import { AuditControllerComponent } from './audit-controller/audit-controller.component';
import { GetAllAuditComponent } from './audit-controller/get-all-audit/get-all-audit.component';
import { GetAllAuditUseridComponent } from './audit-controller/get-all-audit-userid/get-all-audit-userid.component';
import { GetAllAuditDateComponent } from './audit-controller/get-all-audit-date/get-all-audit-date.component';
import { MatDatepickerModule } from '@angular/material/datepicker';

import { MatNativeDateModule } from '@angular/material/core';

import { MatPaginatorModule } from '@angular/material/paginator';
import { SalaryDisburesementComponent } from './salary-disburesement/salary-disburesement.component';
import { UpdateEmployeeSalaryDisburesementComponent } from './salary-disburesement/update-employee-salary-disburesement/update-employee-salary-disburesement.component';
import { ReasonRejectComponent } from './company-controller/reason-reject/reason-reject.component';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { ChangePasswordComponent } from './bank-controller/update-bank-password/change-password/change-password.component';
import { SearchComponent } from './search/search.component';



@NgModule({
  declarations: [
    AdminControllerComponent,
    BankControllerComponent,
    AdminDashboardComponent,
    AddAdminComponent,
    GetAdminComponent,
    RemoveAdminComponent,
    LogoutComponent,
    GetBankComponent,
    AddBankComponent,
    RemoveBankComponent,
    GetBankIdComponent,
    UpdateBankPasswordComponent,
    CompanyControllerComponent,
    UpdatePendingCompaniesComponent,
    TransactionControllerComponent,
    UpdateCompanyPendingTransactionsComponent,
    OutboundBeneficiaryControllerComponent,
    UpdatePendingOutboundBeneficiaryComponent,
    AuditControllerComponent,
    GetAllAuditComponent,
    GetAllAuditUseridComponent,
    GetAllAuditDateComponent,
    SalaryDisburesementComponent,
    UpdateEmployeeSalaryDisburesementComponent,
    ReasonRejectComponent,
    ChangePasswordComponent,
    SearchComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    ReactiveFormsModule,
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
    MatPaginatorModule,
    MatCheckboxModule,
    MatProgressSpinnerModule,
  ]
})
export class AdminModule { }
