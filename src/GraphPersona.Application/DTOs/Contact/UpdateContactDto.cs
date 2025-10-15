using GraphPersona.Domain.Enums;

namespace GraphPersona.Application.DTOs.Contact;

public record UpdateContactDto(
    Guid Id,
    ContactTypeEnum? Channel,
    string? Info
)
{
    public Domain.Entities.Contact? ToEntity()
    {
        if (Channel is null || Info is null)
            return null;
        
        return new Domain.Entities.Contact
        {
            Id = Id,
            Channel = Channel.Value,
            Info = Info.Trim()
        };
    }
}