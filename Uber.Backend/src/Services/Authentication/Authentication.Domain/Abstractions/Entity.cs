using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Domain.Abstractions;
public abstract class Entity<T> : IEntity<T>
{
    public DateTime CreatedAt { get; set; }
    public DateTime LastModified { get; set; }
    public T Id { get; set; }
}
