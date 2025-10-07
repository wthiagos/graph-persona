using GraphPersona.Api.GraphQL.Enums;
using GraphPersona.Api.Models;

namespace GraphPersona.Api.GraphQL.Inputs;

public record AddContactInput(
    ContactTypeEnum Type,
    string Value
)
{
    public Contact ToEntity() => new Contact
    {
        Type = Type,
        Value = Value.Trim()
    };
}

