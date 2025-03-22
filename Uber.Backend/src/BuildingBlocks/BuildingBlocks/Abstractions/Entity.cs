
namespace BuildingBlocks.Abstractions;
public abstract class Entity<T> : IEntity<T>
{
    public DateTime CreatedAt { get; set; }
    public DateTime LastModified { get; set; }
    public required T Id { get; set; }
}
