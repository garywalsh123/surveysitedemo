using Autofac;

namespace SurveySite.Infrastructure
{
    internal class AutofacMediator : IMediator
    {
        private readonly IComponentContext mContainer;

        public AutofacMediator(IComponentContext container)
        {
            mContainer = container;
        }

        public Task<TQueryResult> Execute<TQuery, TQueryResult>(TQuery query, CancellationToken cancellationToken = default)
        {
            var handler = mContainer.Resolve<IQueryHandler<TQuery, TQueryResult>>();
            return handler is null
                ? throw new ArgumentException(
                    $"The query handler was not found for the query type ${typeof(TQuery).FullName} with the result type ${typeof(TQueryResult)}.",
                    nameof(query))
                : handler.Handle(query, cancellationToken);
        }

        public Task<TCommandResult> Send<TCommand, TCommandResult>(TCommand command, CancellationToken cancellationToken = default)
        {
            var handler = mContainer.Resolve<ICommandHandler<TCommand, TCommandResult>>();
            return handler is null
                ? throw new ArgumentException(
                    $"The command handler was not found for the command type ${typeof(TCommand).FullName} with the result type ${typeof(TCommandResult)}.",
                    nameof(command))
                : handler.Handle(command, cancellationToken);
        }

    }
}
