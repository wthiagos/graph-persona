using GraphPersona.Application.DTOs.Address;
using GraphPersona.Application.DTOs.Contact;

namespace GraphPersona.Application.DTOs.Person;

public record UpdatePersonDto(
    string? FullName,
    DateOnly? BirthDate,
    UpdateAddressDto? Address,
    List<UpdateContactDto>? Contacts
);