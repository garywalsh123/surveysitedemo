namespace SurveySite.Infrastructure
{
    public interface IMediator
    {
        Task<TQueryResult> Execute<TQuery, TQueryResult>(TQuery query, CancellationToken cancellationToken = default);

        Task<TCommandResult> Send<TCommand, TCommandResult>(TCommand command, CancellationToken cancellationToken = default);
    }
}
