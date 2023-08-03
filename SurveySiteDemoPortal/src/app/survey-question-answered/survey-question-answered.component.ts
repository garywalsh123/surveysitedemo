import { Component, Input } from '@angular/core';
import { Question } from '../models/question.model';

@Component({
  selector: 'survey-question-answered',
  templateUrl: './survey-question-answered.component.html'
})
export class SurveyQuestionAnsweredComponent {
  @Input() question: Question;
}
