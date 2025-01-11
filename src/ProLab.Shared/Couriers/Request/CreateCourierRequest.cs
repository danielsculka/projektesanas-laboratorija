namespace ProLab.Shared.Couriers.Request;

public class CreateCourierRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsActive { get; set; }
}
