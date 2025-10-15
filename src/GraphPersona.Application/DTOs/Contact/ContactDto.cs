using GraphPersona.Domain.Enums;

namespace GraphPersona.Application.DTOs.Contact;

public record ContactDto(
    Guid Id,
    ContactTypeEnum Channel,
    string Info
);