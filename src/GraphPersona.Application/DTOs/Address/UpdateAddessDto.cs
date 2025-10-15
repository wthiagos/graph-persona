namespace GraphPersona.Application.DTOs.Address;

public record UpdateAddressDto(
    Guid Id,
    string? Street,
    string? City,
    string? ZipCode,
    string? State,
    string? Country
)
{
    public Domain.Entities.Address? ToEntity()
    {
        if (
            string.IsNullOrWhiteSpace(Street) ||
            string.IsNullOrWhiteSpace(City) || 
            string.IsNullOrWhiteSpace(ZipCode) || 
            string.IsNullOrWhiteSpace(State) || 
            string.IsNullOrWhiteSpace(Country)
            )
            return null;
        
        return new Domain.Entities.Address
        {
            Id = Id,
            Street = Street?.Trim(),
            City = City?.Trim(),
            ZipCode = ZipCode?.Trim(),
            State = State?.Trim(),
            Country = Country?.Trim()
        };
    }
}