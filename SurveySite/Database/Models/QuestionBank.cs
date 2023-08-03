namespace SurveySite.Database
{
    public class QuestionBank
    {
        public Guid QuestionBankId { get; set; }
        public string QuestionBankName { get; set; }
        public List<Question> Questions { get; set; }
    }
}
