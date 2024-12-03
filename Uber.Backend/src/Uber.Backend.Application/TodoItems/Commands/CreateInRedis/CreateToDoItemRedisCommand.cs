namespace Uber.Backend.Application.TodoItems.Commands.CreateInRedis;

public sealed record CreateToDoItemRedisCommand(string Title, int? ListId) : IRequest<Result<Guid>>;
