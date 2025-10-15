using GraphPersona.Application.DTOs.Address;
using GraphPersona.Application.DTOs.Contact;

namespace GraphPersona.Application.DTOs.Person;

public record PersonDto(
    Guid Id,
    string FullName,
    DateOnly BirthDate,
    AddressDto? Address,
    IEnumerable<ContactDto>? Contacts
);

