﻿namespace Uber.Backend.Presentation.Grpc.Models;

[ProtoContract]
public sealed record GetTodoItemRequest
{
    [ProtoMember(1)]
    public Guid Id { get; init; }
}
