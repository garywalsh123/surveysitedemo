using SurveySite.Database;

namespace SurveySite.CommandHandlers.Commands
{
    public class StartSurveyResult
    {
        public Guid SurveyId { get; set; }
        public List<Question> Questions { get; set; }
        public Dictionary<Guid, double> AnswerPercentages { get; set; }
        public bool SurveyCompletedInd { get; set; }
    }
}
