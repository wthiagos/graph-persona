using GraphPersona.Application.DTOs.Address;
using GraphPersona.Application.DTOs.Contact;

namespace GraphPersona.Application.DTOs.Person;

public record CreatePersonDto(
    string FullName,
    DateOnly BirthDate,
    CreateAddressDto? Address,
    IEnumerable<CreateContactDto>? Contacts
)
{
    public Domain.Entities.Person ToEntity() => new Domain.Entities.Person
    {
        FullName = FullName.Trim(),
        BirthDate = BirthDate,
        Address = Address?.ToEntity(),
        Contacts = Contacts?.Select(c => c.ToEntity()).ToList()
    };
}