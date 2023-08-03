using Microsoft.EntityFrameworkCore;
using SurveySite.Database;
using SurveySite.Infrastructure;
using SurveySite.QueryHandlers.Queries;

namespace SurveySite.QueryHandlers
{
    public class GetQuestionBankQuestionsQueryHandler : IQueryHandler<GetQuestionBankQuestionsQuery, GetQuestionBankQuestionsResult>
    {
        private readonly SurveySiteContext _context;

        public GetQuestionBankQuestionsQueryHandler(SurveySiteContext context)
        {
            _context = context;
        }

        public async Task<GetQuestionBankQuestionsResult> Handle(GetQuestionBankQuestionsQuery query, CancellationToken cancellationToken = default)
        {
            var questions = await _context.QuestionBank
                .Include(item => item.Questions)
                .Where(item => item.QuestionBankId == query.QuestionBankId)
                .SelectMany(item => item.Questions)
                .ToListAsync(cancellationToken);


            return new GetQuestionBankQuestionsResult()
            {
                Questions = questions
            };
        }
    }
}
