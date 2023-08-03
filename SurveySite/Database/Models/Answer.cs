namespace SurveySite.Database
{
    public class Answer
    {
        public Guid AnswerId { get; set; }
        public Guid QuestionId { get; set; }
        public string AnswerText { get; set; }
        public bool ActiveInd { get; set; }
        public virtual Question Question { get; set; }
    }
}
