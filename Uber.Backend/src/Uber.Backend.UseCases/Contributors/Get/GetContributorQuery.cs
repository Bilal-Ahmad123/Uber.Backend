using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Uber.Backend.UseCases.Contributors.Get;

public record GetContributorQuery(int ContributorId) : IQuery<Result<ContributorDTO>>;
