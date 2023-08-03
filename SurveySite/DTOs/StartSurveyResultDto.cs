namespace SurveySite.DTOs
{
    public class StartSurveyResultDto
    {
        public Guid SurveyId { get; set; }
        public List<QuestionDto> Questions { get; set; }
        public bool SurveyCompletedInd { get; set; }
    }
}
