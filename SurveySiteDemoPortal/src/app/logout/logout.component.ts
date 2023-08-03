import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html'
})
export class LogoutComponent {
  constructor(private router: Router) {}

  isLoggedOut: boolean;

  ngOnInit() {

    if(localStorage.getItem('token')) {
      localStorage.removeItem('token');
    } else {
      this.router.navigate(['home']);
    }
  }
}
