import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SurveyAuthenticationService } from './services/authentiction.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent  implements OnInit{
  title = 'SurveySiteDemoPortal';
  isLoggedIn: boolean;
  constructor(private router: Router, private authService: SurveyAuthenticationService){}
 
 
  ngOnInit(): void {
    this.isLoggedIn = this.authService.isLoggedIn();
  }

  goHome(): void {
    this.router.navigate(['home']);
  }

  isUserLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }

}


