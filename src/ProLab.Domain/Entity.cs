namespace ProLab.Domain;

public abstract class Entity<T> : IEntity<T>, IAuditable
{
    public required T Id { get; set; }

    public required DateTime Created { get; set; } = DateTime.UtcNow;
    public required DateTime Modified { get; set; } = DateTime.UtcNow;

    //public Guid CreatedById { get; set; }
    //public virtual required User CreatedBy { get; set; }

    //public Guid ModifiedById { get; set; }
    //public virtual required User ModifiedBy { get; set; }
}

