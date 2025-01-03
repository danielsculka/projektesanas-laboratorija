using ProLab.Application.Addresses.Models;

namespace ProLab.Application.Orders.Results;

public class OrderResult
{
    public int Id { get; set; }
    public string Number { get; set; }
    public AddressData Address { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
