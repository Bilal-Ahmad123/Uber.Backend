namespace Uber.Backend.Presentation.Rest.Filters.Results;

public sealed class ForbiddenObjectResult : ObjectResult
{
    public ForbiddenObjectResult(object? value) : base(value)
    {
    }
}
