using GraphPersona.Api.Models;

namespace GraphPersona.Api.GraphQL.Inputs;

public record AddAddressInput(
    string Street,
    string City,
    string ZipCode,
    string State,
    string Country
)
{
    public Address ToEntity() => new Address
    {
        Street = Street.Trim(),
        City = City.Trim(),
        ZipCode = ZipCode.Trim(),
        State = State.Trim(),
        Country = Country.Trim()
    };
}

