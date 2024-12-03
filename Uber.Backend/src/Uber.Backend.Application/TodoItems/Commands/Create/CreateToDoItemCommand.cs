﻿namespace Uber.Backend.Application.TodoItems.Commands.Create;

public sealed record CreateToDoItemCommand(string Title, int? ListId) : IRequest<Result<Guid>>;
