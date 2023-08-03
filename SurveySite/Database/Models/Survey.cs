namespace SurveySite.Database
{
    public class Survey
    {
        public Guid SurveyId { get; set; }
        public DateTime SurveyDate { get; set; }
        public Guid? SurveyUserId { get; set; }
        public Guid QuestionBankId { get; set; }
        public string? IpAddress { get; set; }
        public virtual QuestionBank QuestionBank { get; set; }
    }
}
