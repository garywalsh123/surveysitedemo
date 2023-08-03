import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Question } from '../models/question.model';
import { SurveyService } from '../services/survey.service';

@Component({
  selector: 'survey-question',
  templateUrl: './survey-question.component.html'
})
export class SurveyQuestionComponent {
  @Input() question: Question;
  @Input() surveyId: string;

  @Output() nextQuestion = new EventEmitter<Question>();
  
  constructor(private surveyService: SurveyService){}

  async submitAnswer(answerId: string): Promise<void> {
    await this.surveyService.answerQuestion({
      answerId: answerId,
      surveyId: this.surveyId
    })
    this.question.answers.find(item => item.answerId === answerId)!.selected = true;
    this.nextQuestion.emit(this.question);
    this.question.answered = true;
    
  }

}
