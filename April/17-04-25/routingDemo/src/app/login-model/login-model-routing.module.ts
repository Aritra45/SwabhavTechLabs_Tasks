import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponentComponent } from './login-component/login-component.component';
import { RegistrationComponent } from '../registration/registration.component'; // Adjust the path accordingly

const routes: Routes = [
  { path: 'login', component: LoginComponentComponent },
  { path: 'registration', component: LoginComponentComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LoginModelRoutingModule { }
