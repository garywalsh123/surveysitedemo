using AutoMapper;
using SurveySite.BusinessLogic.Contract;
using SurveySite.DTOs;
using SurveySite.Infrastructure;
using SurveySite.QueryHandlers.Queries;

namespace SurveySite.BusinessLogic.Implementation
{
    public class QuestionBankBl : IQuestionBl
    {
        private readonly IMapper mMapper;
        private readonly IMediator mMediator;

        public QuestionBankBl(IMapper mapper, IMediator mediator)
        {
            mMapper = mapper;
            mMediator = mediator;
        }

        /// <inheritdoc />
        public async Task<QuestionBankResultDto> GetQuestionBanks()
        {
            var questionBanks = await mMediator.Execute<GetQuestionBankQuery, GetQuestionBankResult>(new GetQuestionBankQuery());
            return mMapper.Map<QuestionBankResultDto>(questionBanks);
        }

        /// <inheritdoc />
        public async Task<QuestionBankQuestionsResultDto> GetQuestionsByQuestionBank(Guid questionBankId)
        {
            var questions = await mMediator.Execute<GetQuestionBankQuestionsQuery, GetQuestionBankQuestionsResult>(new GetQuestionBankQuestionsQuery() { 
                QuestionBankId = questionBankId
            });
            return mMapper.Map<QuestionBankQuestionsResultDto>(questions);
        }
    }
}
