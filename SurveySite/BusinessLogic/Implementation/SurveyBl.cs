using AutoMapper;
using SurveySite.BusinessLogic.Contract;
using SurveySite.CommandHandlers;
using SurveySite.CommandHandlers.Commands;
using SurveySite.CommandHandlers.Results;
using SurveySite.DTOs;
using SurveySite.Infrastructure;

namespace SurveySite.BusinessLogic.Implementation
{
    public class SurveyBl : ISurveyBl
    {
        private readonly IMapper mMapper;
        private readonly IMediator mMediator;

        public SurveyBl(IMapper mapper, IMediator mediator)
        {
            mMapper = mapper;
            mMediator = mediator;
        }

        /// <inheritdoc />
        public async Task<StartSurveyResultDto> CreateSurvey(Guid? customerIdentifier, string ipAddress)
        {
            var survey = await mMediator.Send<StartSurveyCommand, StartSurveyResult>(new StartSurveyCommand()
            {
                CustomerIdentifier = customerIdentifier,
                IpAddress = ipAddress
            });

            var mappedResults = mMapper.Map<StartSurveyResultDto>(survey);

            foreach(var answer in mappedResults.Questions.SelectMany(item => item.Answers))
            {
                answer.Percentage = survey.AnswerPercentages.TryGetValue(answer.AnswerId, out var value) ? value : 0;
            }

            return mappedResults;
        }

        /// <inheritdoc />
        public async Task AnswerQuestion(SurveyAnswerDto surveyAnswer)
        {
            await mMediator.Send<SaveAnswerCommand, SaveAnswerResult>(new SaveAnswerCommand()
            {
                AnswerId = surveyAnswer.AnswerId,
                SurveyId = surveyAnswer.SurveyId
            });
        }
    }
}
