import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { RegistrationComponent } from './registration/registration.component';
import { AppComponent } from './app.component';
import { LoginComponentComponent } from './login-model/login-component/login-component.component';

const routes: Routes = [
  {path:'login', component:LoginComponentComponent},
  {path:'registration', component:LoginComponentComponent},
  {path:'', component: LoginComponentComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
