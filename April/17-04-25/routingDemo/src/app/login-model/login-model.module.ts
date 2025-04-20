import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoginModelRoutingModule } from './login-model-routing.module';
import { LoginComponentComponent } from './login-component/login-component.component';


@NgModule({
  declarations: [
    LoginComponentComponent
  ],
  imports: [
    CommonModule,
    LoginModelRoutingModule
  ]
})
export class LoginModelModule { 

  
}
