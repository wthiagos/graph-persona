using GraphPersona.Domain.Entities;

namespace GraphPersona.Application.DTOs.Address;

public record CreateAddressDto(
    string Street,
    string City,
    string ZipCode,
    string State,
    string Country
)
{
    public Domain.Entities.Address ToEntity() => new Domain.Entities.Address
    {
        Street = Street.Trim(),
        City = City.Trim(),
        ZipCode = ZipCode.Trim(),
        State = State.Trim(),
        Country = Country.Trim()
    };
}