import { Component } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs';

@Component({
  selector: 'app-header',
  standalone: false,
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  token:any
  showLogoutButton = false;
 constructor(private router:Router){}
  ngOnInit() :void{
    this.router.events
      .pipe(filter(event => event instanceof NavigationEnd))
      .subscribe((event: NavigationEnd) => {
        const token = localStorage.getItem('token'); // or sessionStorage
        this.showLogoutButton = !!token;
        
      });



  }

}
