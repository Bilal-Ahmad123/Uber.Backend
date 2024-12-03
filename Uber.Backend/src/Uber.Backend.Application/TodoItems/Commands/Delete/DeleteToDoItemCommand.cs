namespace Uber.Backend.Application.TodoItems.Commands.Delete;

public sealed record DeleteToDoItemCommand(Guid Id) : IRequest;
