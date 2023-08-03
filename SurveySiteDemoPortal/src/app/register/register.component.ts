import { Component } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { SurveyAuthenticationService } from '../services/authentiction.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent {
  emailVerificationForm: FormGroup;
  registerForm: FormGroup;
  pendingEmailVerification: boolean;

  constructor(
    private formBuilder: FormBuilder,
    private surveyAuthenticationService: SurveyAuthenticationService,
    private router: Router) {}

  ngOnInit() {

    if(this.surveyAuthenticationService.isLoggedIn()) {
      this.router.navigate(['home']);
    }

    this.registerForm = this.formBuilder.group({
      username: '',
      password: ''
    });
  }

  onSubmit(): void {
    const registerRequest = {
      username: this.registerForm.get('username')?.value,
      password: this.registerForm.get('password')?.value
    }

    this.surveyAuthenticationService.register(registerRequest).subscribe((item) => {
      this.pendingEmailVerification = true;
    });
    this.registerForm.reset();
  }

  onVerifyEmail(): void {
    
  }
}
