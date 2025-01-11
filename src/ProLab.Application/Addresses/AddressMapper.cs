using ProLab.Application.Addresses.Models;
using ProLab.Domain.Addresses;

namespace ProLab.Application.Addresses;

internal static class AddressMapper
{
    public static Address ToEntity(this AddressData data, Address entity)
    {
        entity.Street = data.Street;
        entity.City = data.City;
        entity.District = data.District;
        entity.Parish = data.Parish;
        entity.PostalCode = data.PostalCode;
        entity.Location = data.Location;

        return entity;
    }

    public static AddressData FromEntity(this Address entity)
    {
        return new AddressData
        {
            Street = entity.Street,
            City = entity.City,
            District = entity.District,
            Parish = entity.Parish,
            PostalCode = entity.PostalCode,
            Location = entity.Location,
        };
    }
}
