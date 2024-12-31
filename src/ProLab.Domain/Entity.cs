namespace ProLab.Domain;

public abstract class Entity<T> : IEntity<T>, IAuditable
{
    public T Id { get; set; }

    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime Modified { get; set; } = DateTime.UtcNow;

    //public Guid CreatedById { get; set; }
    //public virtual required User CreatedBy { get; set; }

    //public Guid ModifiedById { get; set; }
    //public virtual required User ModifiedBy { get; set; }
}

