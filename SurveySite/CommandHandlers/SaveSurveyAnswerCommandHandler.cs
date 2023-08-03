using SurveySite.CommandHandlers.Commands;
using SurveySite.CommandHandlers.Results;
using SurveySite.Database;
using SurveySite.Infrastructure;

namespace SurveySite.CommandHandlers
{
    public class SaveSurveyAnswerCommandHandler : ICommandHandler<SaveAnswerCommand, SaveAnswerResult>
    {
        private readonly SurveySiteContext _context;

        public SaveSurveyAnswerCommandHandler(SurveySiteContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Save an answer for a given survey.
        /// If an identifier (logged in user) provided, check and make sure this survey belongs to that user
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<SaveAnswerResult> Handle(SaveAnswerCommand command, CancellationToken cancellationToken = default)
        {
            //Validate the survey input to be sure its a legitmate survey
            var survey = _context.Survey.First(item => item.SurveyId == command.SurveyId) ?? throw new SurveyException("Survey does not exist");
           
            //If there is an identifier passed in, make sure its the same as the survey (prevent someone answering someone elses)
            if (command.CustomerIdentifier.HasValue && (survey.SurveyUserId != command.CustomerIdentifier))
            {
                throw new SurveyException("You are not authorised to access this survey");
            }

            _context.Add(new SurveyAnswer() { 
                AnswerId = command.AnswerId,
                SurveyId = command.SurveyId
            });
            await _context.SaveChangesAsync(cancellationToken);

            return new SaveAnswerResult()
            {
            };
        }
    }
}
