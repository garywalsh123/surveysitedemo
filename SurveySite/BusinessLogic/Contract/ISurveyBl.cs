using SurveySite.DTOs;

namespace SurveySite.BusinessLogic.Contract
{
    public interface ISurveyBl
    {
        /// <summary>
        /// Create a survey for a user. This will use a random question bank and return a survey configured with a list of questions.
        /// If the user has completed all the daily surveys then return a flag to state 
        /// </summary>
        /// <param name="customerIdentifier"></param>
        /// <returns></returns>
        public Task<StartSurveyResultDto> CreateSurvey(Guid? customerIdentifier, string ipAddress);

        /// <summary>
        /// Save an answer for a survey question.
        /// </summary>
        /// <param name="surveyAnswer"></param>
        /// <returns></returns>
        public Task AnswerQuestion(SurveyAnswerDto surveyAnswer);
    }
}
