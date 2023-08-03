using Microsoft.EntityFrameworkCore;
using SurveySite.Database;
using SurveySite.Infrastructure;
using SurveySite.QueryHandlers.Queries;

namespace SurveySite.QueryHandlers
{
    public class GetQuestionBankQueryHandler : IQueryHandler<GetQuestionBankQuery, GetQuestionBankResult>
    {
        private readonly SurveySiteContext _context;

        public GetQuestionBankQueryHandler(SurveySiteContext context)
        {
            _context = context;
        }

        public async Task<GetQuestionBankResult> Handle(GetQuestionBankQuery query, CancellationToken cancellationToken = default)
        {
            var questionBanks = await _context.QuestionBank.ToListAsync(cancellationToken);

            return new GetQuestionBankResult()
            {
                QuestionBanks = questionBanks
            };
        }
    }
}
