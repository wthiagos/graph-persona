using GraphPersona.Application.DTOs.Person;

namespace GraphPersona.Api.GraphQL.Inputs.Add;

public record AddPersonInput(
    string FullName,
    DateOnly BirthDate,
    AddAddressInput? Address,
    IEnumerable<AddContactInput>? Contacts
)
{
    public CreatePersonDto ToDto() => new CreatePersonDto
    (
        FullName.Trim(),
        BirthDate,
        Address?.ToDto(),
        Contacts?.Select(c => c.ToDto())
    );
}
