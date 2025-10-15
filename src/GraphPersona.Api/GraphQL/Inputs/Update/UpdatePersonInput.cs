using GraphPersona.Application.DTOs.Person;

namespace GraphPersona.Api.GraphQL.Inputs.Update;

public record UpdatePersonInput(
    string? FullName,
    DateOnly? BirthDate,
    UpdateAddressInput? Address,
    List<UpdateContactInput>? Contacts
)
{
    public UpdatePersonDto ToDto() => new UpdatePersonDto
    (
        FullName?.Trim(),
        BirthDate,
        Address?.ToDto(),
        Contacts
            ?.Select(c => c?.ToDto())
            .ToList()!
    );
}
