import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AppComponent } from './app.component';
import { AuthGuardServiceService } from './auth-guard-service.service';

const routes: Routes = [
  {path:'', component:AppComponent},
  { path: 'home', component: HomeComponent, canActivate: [AuthGuardServiceService],data: { role: 'Admin' }},
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
