import { Question } from "./question.model";

export class Survey {
    surveyId: string;
    questions: Question[]; 
    surveyCompletedInd: boolean;
}