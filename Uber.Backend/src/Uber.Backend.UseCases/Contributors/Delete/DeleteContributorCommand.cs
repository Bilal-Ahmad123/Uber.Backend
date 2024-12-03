using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Uber.Backend.UseCases.Contributors.Delete;

public record DeleteContributorCommand(int ContributorId) : ICommand<Result>;
