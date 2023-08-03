import { Component, OnInit } from '@angular/core';

import { SurveyService } from '../services/survey.service';
import { Survey } from '../models/survey.model';
import { ActivatedRoute, Router } from '@angular/router';
import { Question } from '../models/question.model';
import { SurveyAuthenticationService } from '../services/authentiction.service';

@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html'
})
export class SurveyComponent implements OnInit {

  constructor(
    private surveyService: SurveyService,
    private router: Router,
    private authService: SurveyAuthenticationService
  ){}

  answeredQuestions: Question[] = [];
  currentQuestion: Question;
  isDailySurveyCompleted: boolean;
  isFinishedSurvey: boolean;
  isLoggedIn: boolean;
  isLoading: boolean;
  survey: Survey;
  
  ngOnInit(): void {
    this.isLoading = true;
    this.isLoggedIn = this.authService.isLoggedIn();
    this.surveyService.startSurvey().subscribe((res: Survey) => {
      if(res.surveyCompletedInd) {
        this.isDailySurveyCompleted = true;
        this.isLoading = false;
        return;
      }
      this.survey = res;
      this.currentQuestion = this.survey.questions.pop() as Question;
      this.isLoading = false;
    });
  }


  getNextQuestion(question: Question): void {
    this.answeredQuestions.push(question);
    if(this.survey.questions.length == 0) {
      this.isFinishedSurvey = true;
    } else {
      this.currentQuestion = this.survey.questions.pop() as Question;
    }  
  }

  navigateTo(url: string): void {
    this.router.navigate([url]);
  }
}
