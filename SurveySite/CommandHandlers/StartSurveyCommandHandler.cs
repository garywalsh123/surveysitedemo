using Microsoft.EntityFrameworkCore;
using SurveySite.CommandHandlers.Commands;
using SurveySite.Database;
using SurveySite.Infrastructure;

namespace SurveySite.CommandHandlers
{
    public class StartSurveyCommandHandler : ICommandHandler<StartSurveyCommand, StartSurveyResult>
    {
        private readonly SurveySiteContext _context;

        public StartSurveyCommandHandler(SurveySiteContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Generate a survey for a given customer. If the customer is logged in, check their identifier and see if they've done all the daily surveys
        /// If they have no identifier (i.e. anonymous) check their IpAddress to see if they've done all the surveys today
        /// If all surveys done, return a flag to indicate
        /// Else generate a random bank and calculate the current answer percentages
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<StartSurveyResult> Handle(StartSurveyCommand command, CancellationToken cancellationToken = default)
        {
            var currentDate = DateTime.Today;

            //check for any surveys the user has done today
            //If their is an identifier use that, otherwise check based on IpAddress
            var query = _context.Survey.Where(item => item.SurveyDate == currentDate);
            if (command.CustomerIdentifier.HasValue)
            {
                query = query.Where(item => item.SurveyUserId == command.CustomerIdentifier.Value);
            }
            else
            {
                query = query.Where(item => item.IpAddress == command.IpAddress);
            }

            var userSurveys = await query.ToListAsync(cancellationToken: cancellationToken);

            //Calculate what bank we want to use
            //For now, just pick the first one
            var selectedQuestionBank = await SelectQuestionBank(userSurveys, cancellationToken);

            //If all completed, tell the user they're done for the day
            if (selectedQuestionBank == null)
            {
                return new StartSurveyResult()
                {
                    SurveyCompletedInd = true
                };
            }

            //Get the questions for the selected bank
            var questionBankQuestions = await _context.QuestionBank
                .Include(item => item.Questions)
                .ThenInclude(item => item.Answers)
                .Where(item => item.QuestionBankId == selectedQuestionBank)
                .SelectMany(item => item.Questions)
                .ToListAsync(cancellationToken: cancellationToken);

            var answerPercentages = await CalculateAnswerPercentages(questionBankQuestions, cancellationToken);

            //Create a survey for general questions.
            var surveyToCreate = new Survey()
            {
                SurveyDate = currentDate,
                SurveyUserId = command.CustomerIdentifier,
                QuestionBankId = selectedQuestionBank.Value,
                IpAddress = command.IpAddress
            };

            _context.Add(surveyToCreate);
            await _context.SaveChangesAsync(cancellationToken);

            return new StartSurveyResult()
            {
                SurveyId = surveyToCreate.SurveyId,
                Questions = questionBankQuestions,
                AnswerPercentages = answerPercentages
            };
        }

        /// <summary>
        /// Generate a random question bank
        /// </summary>
        /// <param name="customerIdentifier"></param>
        /// <returns></returns>
        private async Task<Guid?> SelectQuestionBank(List<Survey> surveys, CancellationToken cancellationToken)
        {
            var alreadyPerformedSurveys = surveys.Select(item => item.QuestionBankId);

            //Get question banks not done by this user
            var questionBanks = await _context.QuestionBank.Where(item => !alreadyPerformedSurveys.Contains(item.QuestionBankId)).ToListAsync(cancellationToken: cancellationToken);

            if (!questionBanks.Any())
            {
                return null;
            }

            var random = new Random();
            var index = random.Next(questionBanks.Count);

            //TODO: 
            /*
             * This is where AI and enhanced logic could dictate what bank to show e.g. geo-location
             * 
             */

            return questionBanks[index].QuestionBankId;
        }

        /// <summary>
        /// For all the questions that are in this bank, get the percentage of previously answered questions
        /// </summary>
        /// <param name="questionBankQuestions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task<Dictionary<Guid, double>> CalculateAnswerPercentages(List<Question> questionBankQuestions, CancellationToken cancellationToken)
        {          
            //Get all the question ids for this bank
            var questionIds = questionBankQuestions
               .GroupBy(item => item.QuestionId)
               .Select(item => item.Key)
               .ToArray();

            //calculate all the other answers to these answers
            var currentAnswersByQuestion = await _context.SurveyAnswer
                .Include(t => t.Answer)
                .ThenInclude(t => t.Question)
                .Where(item => questionIds.Contains(item.Answer.QuestionId))
                .GroupBy(key => key.Answer.QuestionId)
                .Select(group => group.ToList())
                .ToListAsync(cancellationToken: cancellationToken);

            var result = new Dictionary<Guid, double>();
            foreach (var answersByQuestion in currentAnswersByQuestion)
            {
                var answer = answersByQuestion
                    .GroupBy(item => item.AnswerId)
                    .Select(item => new
                    {
                        AnswerId = item.Key,
                        Percentage = Math.Floor(((double)item.Count() / answersByQuestion.Count * 100))
                    });

                foreach (var item in answer)
                {
                    result.Add(item.AnswerId, item.Percentage);
                }
            }

            return result;
        }
    }
}
