using GraphPersona.Application.DTOs.Contact;
using GraphPersona.Domain.Enums;

namespace GraphPersona.Api.GraphQL.Inputs.Update;

public record UpdateContactInput(
    Guid Id,
    ContactTypeEnum? Channel,
    string? Info
)
{
    public UpdateContactDto? ToDto()
    {
        if (Channel is null && Info is null)
            return null;
        
        return new UpdateContactDto
        (
            Id,
            Channel,
            Info?.Trim()
        );
    }
}