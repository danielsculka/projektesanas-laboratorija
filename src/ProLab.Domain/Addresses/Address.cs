using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace ProLab.Domain.Addresses;

public class Address : Entity<Guid>
{
    [MaxLength(150)]
    public required string Street { get; set; }

    [MaxLength(75)]
    public string? City { get; set; }

    [MaxLength(75)]
    public string? District { get; set; }

    [MaxLength(75)]
    public string? Parish { get; set; }

    [MaxLength(10)]
    public required string PostalCode { get; set; }

    public required Point Location { get; set; }
}
