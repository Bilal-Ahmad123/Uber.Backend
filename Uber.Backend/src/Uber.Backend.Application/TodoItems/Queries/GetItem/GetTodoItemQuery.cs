namespace Uber.Backend.Application.TodoItems.Queries.GetItem;

using Uber.Backend.Application.Models;

public sealed record GetTodoItemQuery(Guid Id) : IRequest<Result<ToDoItemDto>>;
