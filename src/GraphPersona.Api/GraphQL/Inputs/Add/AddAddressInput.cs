using GraphPersona.Application.DTOs.Address;

namespace GraphPersona.Api.GraphQL.Inputs.Add;

public record AddAddressInput(
    string Street,
    string City,
    string ZipCode,
    string State,
    string Country
)
{
    public CreateAddressDto ToDto() => new CreateAddressDto
    (
        Street.Trim(),
        City.Trim(),
        ZipCode.Trim(),
        State.Trim(),
        Country.Trim()
    );
}