namespace SurveySite.Database
{
    public class Question
    {
        public Guid QuestionId { get; set; }
        public string QuestionText { get; set; }
        public bool ActiveInd { get; set; }
        public virtual List<Answer> Answers { get; set; }
        public virtual List<QuestionBank> QuestionBanks { get; set; }
    }
}
