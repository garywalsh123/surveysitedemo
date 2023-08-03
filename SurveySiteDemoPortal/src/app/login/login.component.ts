import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { SurveyAuthenticationService } from '../services/authentiction.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private surveyAuthenticationService: SurveyAuthenticationService,
    private router: Router) {}

  ngOnInit() {

    if(localStorage.getItem('token')) {
      this.router.navigate(['home']);
    }

    this.loginForm = this.formBuilder.group({
      username: '',
      password: ''
    });
  }

  onSubmit(): void {
    const loginRequest = {
      username: this.loginForm.get('username')?.value,
      password: this.loginForm.get('password')?.value
    }

    this.surveyAuthenticationService.login(loginRequest).subscribe((item) => {
      localStorage.setItem('token', item.jwt);
      this.router.navigate(['home']);
    });
    this.loginForm.reset();
  }
}
