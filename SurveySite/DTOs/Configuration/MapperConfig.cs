using AutoMapper;
using SurveySite.CommandHandlers.Commands;
using SurveySite.Database;

namespace SurveySite.DTOs.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Answer, AnswerDto>();
            CreateMap<Question, QuestionDto>();
            CreateMap<StartSurveyResult, StartSurveyResultDto>();
        }
    }
}
