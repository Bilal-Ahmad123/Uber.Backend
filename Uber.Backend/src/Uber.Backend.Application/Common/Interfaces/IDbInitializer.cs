﻿namespace Uber.Backend.Application.Common.Interfaces;

public interface IDbInitializer
{
    Task SeedAsync(IApplicationDbContext context, CancellationToken cancellationToken = default);
}
