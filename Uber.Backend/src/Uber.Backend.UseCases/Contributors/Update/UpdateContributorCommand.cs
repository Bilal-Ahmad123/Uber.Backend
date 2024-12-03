using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Uber.Backend.UseCases.Contributors.Update;

public record UpdateContributorCommand(int ContributorId, string NewName) : ICommand<Result<ContributorDTO>>;
