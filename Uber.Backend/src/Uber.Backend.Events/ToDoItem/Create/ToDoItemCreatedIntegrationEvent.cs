namespace Uber.Backend.Events.ToDoItem.Create;

using Interfaces;

public sealed record ToDoItemCreatedIntegrationEvent(Guid Id, string Title, string? Note) : IIntegrationEvent;
