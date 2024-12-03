﻿namespace Uber.Backend.Presentation.Grpc.Models.ToDoItem;

using Result;

[ProtoContract]
public sealed record ToDoItemsResponse : ResultResponse
{
    [ProtoMember(1)]
    public ToDoItemDto[] Items { get; init; } = Array.Empty<ToDoItemDto>();
}
