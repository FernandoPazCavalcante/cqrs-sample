using System;

namespace SimpleCQRSApi.Domain.Common;

public abstract class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
}
