import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { APP_BASE_HREF } from '@angular/common';

import { SurveyComponent } from './survey/survey.component';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { LoginComponent } from './login/login.component';
import { LogoutComponent } from './logout/logout.component';
import { RegisterComponent } from './register/register.component';


const routes: Routes = [
  {
    path: 'home', 
    component: HomeComponent,
  },
  {
    path: 'login', 
    component: LoginComponent,
  },
  {
    path: 'register', 
    component: RegisterComponent,
  },
  {
    path: 'logout', 
    component: LogoutComponent,
  },
  { path: 'surveys', component: SurveyComponent },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  providers: [{ provide: APP_BASE_HREF, useValue: '/' }],
  exports: [RouterModule]
})
export class AppRoutingModule { }
