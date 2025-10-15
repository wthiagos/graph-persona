using GraphPersona.Application.DTOs.Address;

namespace GraphPersona.Api.GraphQL.Inputs.Update;

public record UpdateAddressInput(
    Guid Id,
    string? Street,
    string? City,
    string? ZipCode,
    string? State,
    string? Country
)
{
    public UpdateAddressDto ToDto() => new UpdateAddressDto
    (
        Id,
        Street?.Trim(),
        City?.Trim(),
        ZipCode?.Trim(),
        State?.Trim(),
        Country?.Trim()
    );
}