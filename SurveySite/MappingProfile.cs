using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using AutoMapper;
using SurveySite.DTOs;
using SurveySite.Database;
using SurveySite.CommandHandlers.Commands;
using SurveySite.QueryHandlers.Queries;
using SurveySite.CommandHandlers.Results;

namespace SurveySite
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Question, QuestionDto>();
            CreateMap<QuestionBank, QuestionBankDto>();
            CreateMap<SurveyAnswer, SurveyAnswerDto>();
            CreateMap<Answer, AnswerDto>();
            CreateMap<StartSurveyResult, StartSurveyResultDto>();
            CreateMap<GetQuestionBankResult, QuestionBankResultDto>();
            CreateMap<GetQuestionBankQuestionsResult, QuestionBankQuestionsResultDto>();
            CreateMap<LoginResult, LoginResponseDto>();
            CreateMap<RegisterResult, RegisterResponseDto>();
        }
    }
}
