import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SurveyQuestionComponent } from './survey-question.component';

describe('SurveyQuestionComponent', () => {
  let component: SurveyQuestionComponent;
  let fixture: ComponentFixture<SurveyQuestionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SurveyQuestionComponent]
    });
    fixture = TestBed.createComponent(SurveyQuestionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
