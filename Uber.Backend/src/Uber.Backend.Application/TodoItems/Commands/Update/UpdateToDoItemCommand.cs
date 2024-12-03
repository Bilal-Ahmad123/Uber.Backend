namespace Uber.Backend.Application.TodoItems.Commands.Update;

public sealed record UpdateToDoItemCommand(Guid Id, string Title, string Description) : IRequest;
