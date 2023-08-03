using SurveySite.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveySiteAPITests
{
    public class TestData
    {
        public virtual List<QuestionBank> GetFakeQuestionBanks()
        {
            return new List<QuestionBank>()
            {
                new QuestionBank()
                {
                   QuestionBankId = Guid.NewGuid(),
                   QuestionBankName = "BANK 1",
                   Questions = new List<Question>(){ 
                        new Question(){ 
                            QuestionId = Guid.NewGuid(),   
                            QuestionText = "TEST QUESTION 1"
                        }
                   }
                },
                new QuestionBank()
                {
                   QuestionBankId = Guid.NewGuid(),
                   QuestionBankName = "BANK 2",
                   Questions = new List<Question>(){
                        new Question(){
                            QuestionId = Guid.NewGuid(),
                            QuestionText = "TEST QUESTION 2"
                        }
                   }
                },
                new QuestionBank()
                {
                   QuestionBankId = Guid.NewGuid(),
                   QuestionBankName = "BANK 3",
                   Questions = new List<Question>(){
                        new Question(){
                            QuestionId = Guid.NewGuid(),
                            QuestionText = "TEST QUESTION 3"
                        }
                   }
                },
                new QuestionBank()
                {
                   QuestionBankId = Guid.NewGuid(),
                   QuestionBankName = "BANK 4",
                   Questions = new List<Question>(){
                        new Question(){
                            QuestionId = Guid.NewGuid(),
                            QuestionText = "TEST QUESTION 4"
                        }
                   }
                },
            };
        }

        public static List<Question> GetFakeQuestions()
        {
            return new List<Question>()
            {
                new Question(){
                    QuestionId = Guid.NewGuid(),
                    QuestionText = "TEST QUESTION 1"
                }
            };
        }
    }
}
