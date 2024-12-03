namespace Uber.Backend.Domain.Events;

public sealed record ToDoItemUpdatedDomainEvent(Guid Id, string Name, string? Note) : INotification;
