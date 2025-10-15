using GraphPersona.Domain.Enums;

namespace GraphPersona.Application.DTOs.Contact;

public record CreateContactDto(
    ContactTypeEnum Channel,
    string Info
)
{
    public Domain.Entities.Contact ToEntity() => new Domain.Entities.Contact
    {
        Channel = Channel,
        Info = Info.Trim()
    };
}
