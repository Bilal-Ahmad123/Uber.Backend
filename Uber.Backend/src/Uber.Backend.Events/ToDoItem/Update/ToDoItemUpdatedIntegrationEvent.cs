namespace Uber.Backend.Events.ToDoItem.Update;

using Interfaces;

public sealed record ToDoItemUpdatedIntegrationEvent(Guid Id, string Name) : IIntegrationEvent;
