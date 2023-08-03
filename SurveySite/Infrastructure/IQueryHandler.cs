﻿namespace SurveySite.Infrastructure
{
    public interface IQueryHandler<in TQuery, TQueryResult>
    {
        Task<TQueryResult> Handle(TQuery query, CancellationToken cancellationToken = default);
    }
}
