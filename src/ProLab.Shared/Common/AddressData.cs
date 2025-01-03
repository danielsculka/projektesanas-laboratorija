using NetTopologySuite.Geometries;

namespace ProLab.Shared.Common;

public class AddressData
{
    public string Street { get; set; }
    public string? City { get; set; }
    public string? District { get; set; }
    public string? Parish { get; set; }
    public string PostalCode { get; set; }
    public Coordinate Location { get; set; }
}
