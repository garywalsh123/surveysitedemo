namespace SurveySite.CommandHandlers.Commands
{
    public class SaveAnswerCommand
    {
        public Guid? CustomerIdentifier { get; set; }
        public Guid AnswerId { get; set; }
        public Guid SurveyId { get; set; }
    }
}
