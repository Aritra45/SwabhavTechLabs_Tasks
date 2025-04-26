import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import{CompanyRegistrationComponent} from './company-registration/company-registration.component'
import { VerifyOtpRegisterCompanyComponent } from './verify-otp-register-company/verify-otp-register-company.component';

const routes: Routes = [
  {path:'register-company', component:CompanyRegistrationComponent},
  {path:'verify-company', component:VerifyOtpRegisterCompanyComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RegistrationCompanyRoutingModule { }
