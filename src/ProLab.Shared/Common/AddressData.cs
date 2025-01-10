namespace ProLab.Shared.Common;

public class AddressData
{
    public string Street { get; set; }
    public string? City { get; set; }
    public string? District { get; set; }
    public string? Parish { get; set; }
    public string PostalCode { get; set; }
    public CoordinateData Location { get; set; }

    public override string ToString()
    {
        var parts = new List<string?>
        {
            Street,
            City,
            District,
            Parish,
            PostalCode
        };

        return string.Join(", ", parts.Where(part => !string.IsNullOrEmpty(part)));
    }
}
