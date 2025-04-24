import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuardServiceService } from './auth-guard-service.service';

const routes: Routes = [
  { path: '', redirectTo: 'auth-login/login', pathMatch: 'full' },
  { path: 'auth-login', loadChildren: () => import('./auth-login/auth-login.module').then(m => m.AuthLoginModule), },
  
  {
    path: 'admin-dashboard', loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule), canActivate: [AuthGuardServiceService], data: { role: 'Admin' }
  },

  {
    path: 'bank-dashboard', loadChildren: () => import('./bank/bank.module').then(m => m.BankModule), canActivate: [AuthGuardServiceService], data: { role: 'Bank' }
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
