namespace GraphPersona.Application.DTOs.Address;

public record AddressDto(
    Guid Id,
    string Street,
    string City,
    string ZipCode,
    string State,
    string Country
);