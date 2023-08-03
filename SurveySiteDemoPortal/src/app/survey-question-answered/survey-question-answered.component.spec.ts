import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SurveyQuestionAnsweredComponent } from './survey-question-answered.component';

describe('SurveyQuestionAnsweredComponent', () => {
  let component: SurveyQuestionAnsweredComponent;
  let fixture: ComponentFixture<SurveyQuestionAnsweredComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SurveyQuestionAnsweredComponent]
    });
    fixture = TestBed.createComponent(SurveyQuestionAnsweredComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
