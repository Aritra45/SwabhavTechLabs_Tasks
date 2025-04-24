import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardServiceService implements CanActivate {

  constructor(private router: Router) { }
 
  canActivate(route: ActivatedRouteSnapshot): boolean {
    const token = localStorage.getItem('token');
    if (!token) {
      this.router.navigate(['/home'], { queryParams: { alert: 'Please login first' } });
      alert("Please Login First")
      return false;
    }
    const userRole = this.getUserRole(token);
    const expectedRole = route.data['role']; // Expected role from route
 
    if (userRole !== expectedRole) {
      this.router.navigate(['/home']); // Redirect unauthorized users
      localStorage.removeItem('token')
      alert('Access Denied');
      return false;
    }
    return true;
  }
  getUserRole(token: string): string {
    try {
      const payload = JSON.parse(atob(token.split('.')[1])); // Decode JWT
      return payload['role'] || payload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] || '';
    } catch (error) {
      return '';
    }
  }
}
