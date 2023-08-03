import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

import { Observable, catchError, of } from 'rxjs';

import { LoginResponse } from '../models/login-response.model';
import { LoginRequest } from '../models/login-request.model';
import { RegisterRequest } from '../models/register-request.model';
import { RegisterResponse } from '../models/register-response.model';
import { NgToastService } from 'ng-angular-popup';
import { environment } from '../../environments/environment';

@Injectable()
export class SurveyAuthenticationService {
  constructor(private httpClient: HttpClient,    
    private notificationService: NgToastService) {}

  isLoggedIn(): boolean {
    return localStorage.getItem('token') !== null;
  }
  
  login(loginRequest: LoginRequest): Observable<LoginResponse> {
    return this.httpClient.post<any>(`${environment.apiUrl}user/login`, loginRequest);
  }

  register(request: RegisterRequest): Observable<RegisterResponse> {
    return this.httpClient.post<RegisterResponse>(`${environment.apiUrl}user/register`, request).pipe(catchError((err: HttpErrorResponse) => {
      this.notificationService.error({detail: 'Error', summary: err.error, duration: 5000 });
      return of();
    }));
  }
}
