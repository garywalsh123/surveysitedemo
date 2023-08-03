import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SurveyComponent } from './survey/survey.component';
import { SurveyService } from './services/survey.service';
import { HttpClientModule } from '@angular/common/http';
import { SurveyQuestionComponent } from './survey-question/survey-question.component';
import { HomeComponent } from './home/home.component';
import { SurveyQuestionAnsweredComponent } from './survey-question-answered/survey-question-answered.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { LoginComponent } from './login/login.component';
import { SurveyAuthenticationService } from './services/authentiction.service';
import { RegisterComponent } from './register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LogoutComponent } from './logout/logout.component';
import { NgToastModule } from 'ng-angular-popup';

@NgModule({
  declarations: [
    AppComponent,
    SurveyComponent,
    SurveyQuestionComponent,
    HomeComponent,
    SurveyQuestionAnsweredComponent,
    NotFoundComponent,
    LoginComponent,
    RegisterComponent,
    LogoutComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgToastModule
  ],
  providers: [SurveyService, SurveyAuthenticationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
