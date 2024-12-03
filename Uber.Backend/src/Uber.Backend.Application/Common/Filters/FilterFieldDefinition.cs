namespace Uber.Backend.Application.Common.Filters;

public sealed record FilterFieldDefinition<T>
{
    public T? Value { get; init; }
}