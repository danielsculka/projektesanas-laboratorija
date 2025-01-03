using ProLab.Application.Common.Query;
using ProLab.Shared.Common;

namespace ProLab.Api.Common;

internal static class MappingExtensions
{
    public static PagingParameters ToParameters(this PagingData data)
    {
        return new PagingParameters
        {
            CurrentPage = data.CurrentPage,
            PageSize = data.PageSize
        };
    }

    public static Application.Addresses.Models.AddressData ToData(this AddressData data)
    {
        return new Application.Addresses.Models.AddressData
        {
            Street = data.Street,
            City = data.City,
            District = data.District,
            Parish = data.Parish,
            PostalCode = data.PostalCode,
            Location = data.Location
        };
    }

    public static AddressData ToData(this Application.Addresses.Models.AddressData data)
    {
        return new AddressData
        {
            Street = data.Street,
            City = data.City,
            District = data.District,
            Parish = data.Parish,
            PostalCode = data.PostalCode,
            Location = data.Location
        };
    }
}
