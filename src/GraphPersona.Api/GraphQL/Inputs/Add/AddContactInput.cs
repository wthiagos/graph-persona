using GraphPersona.Application.DTOs.Contact;
using GraphPersona.Domain.Enums;

namespace GraphPersona.Api.GraphQL.Inputs.Add;

public record AddContactInput(
    ContactTypeEnum Channel,
    string Info
)
{
    public CreateContactDto ToDto() => new CreateContactDto
    (
        Channel,
        Info.Trim()
    );
}