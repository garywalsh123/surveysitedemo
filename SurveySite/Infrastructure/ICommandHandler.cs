namespace SurveySite.Infrastructure
{
    public interface ICommandHandler<in TCommand, TCommandResult>
    {
        Task<TCommandResult> Handle(TCommand command, CancellationToken cancellationToken = default);
    }
}
