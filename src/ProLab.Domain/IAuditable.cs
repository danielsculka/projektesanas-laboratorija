namespace ProLab.Domain;

public interface IAuditable
{
    DateTime Created { get; set; }
    //Guid CreatedById { get; set; }
    DateTime Modified { get; set; }
    //Guid ModifiedById { get; set; }
}
