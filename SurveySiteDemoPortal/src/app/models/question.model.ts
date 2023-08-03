import { Answer } from "./answer.model";

export class Question {
    questionId: string;
    questionText: string;
    answers: Answer[];

    answered: boolean;
}