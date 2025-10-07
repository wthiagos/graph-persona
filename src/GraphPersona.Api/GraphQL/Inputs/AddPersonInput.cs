using GraphPersona.Api.Models;

namespace GraphPersona.Api.GraphQL.Inputs;

public record AddPersonInput(
    string FullName,
    DateOnly BirthDate,
    AddAddressInput? Address,
    List<AddContactInput>? Contacts
)
{
    public Person ToEntity() => new Person
    {
        FullName = FullName.Trim(),
        BirthDate = BirthDate,
        Address = Address?.ToEntity(),
        Contacts = Contacts?.Select(c => c.ToEntity()).ToList()
    };
}
