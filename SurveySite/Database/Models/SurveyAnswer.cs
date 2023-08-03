namespace SurveySite.Database
{
    public class SurveyAnswer
    {
        public Guid SurveyAnswerId { get; set; }
        public Guid SurveyId { get; set; }
        public Guid AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
        public virtual Survey Survey { get; set; }
    }
}
