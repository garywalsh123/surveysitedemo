using SurveySite.DTOs;
using SurveySite.QueryHandlers.Queries;

namespace SurveySite.BusinessLogic.Contract
{
    public interface IQuestionBl
    {
        /// <summary>
        /// Get all the question banks
        /// </summary>
        /// <returns></returns>
        public Task<QuestionBankResultDto> GetQuestionBanks();

        /// <summary>
        /// Get all the questions for a specific question bank
        /// </summary>
        /// <param name="questionBankId"></param>
        /// <returns></returns>
        public Task<QuestionBankQuestionsResultDto> GetQuestionsByQuestionBank(Guid questionBankId);
    }
}
