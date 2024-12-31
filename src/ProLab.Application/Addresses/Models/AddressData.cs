using NetTopologySuite.Geometries;

namespace ProLab.Application.Addresses.Models;

public class AddressData
{
    public string Street { get; set; }
    public string? City { get; set; }
    public string? District { get; set; }
    public string? Parish { get; set; }
    public string PostalCode { get; set; }
    public Point Location { get; set; }
}
