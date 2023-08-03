import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, lastValueFrom } from 'rxjs';

import { Survey } from '../models/survey.model';
import { SurveyAnswer } from '../models/survey-answer.model';
import { NgToastService } from 'ng-angular-popup';
import { environment } from '../../environments/environment';


@Injectable()
export class SurveyService {
  constructor(private httpClient: HttpClient) {}

  startSurvey(): Observable<Survey> {
    return this.httpClient.post<any>(`${environment.apiUrl}survey`, null);
  }

  answerQuestion(answer: SurveyAnswer): Promise<SurveyAnswer> {
    return lastValueFrom(this.httpClient.put<SurveyAnswer>(`${environment.apiUrl}survey`, answer));
  }
}
