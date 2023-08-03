namespace SurveySite.CommandHandlers.Commands
{
    public class StartSurveyCommand
    {
        public Guid? CustomerIdentifier { get; set; }
        public string? IpAddress { get; set; }
    }
}
