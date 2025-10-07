using GraphPersona.Api.GraphQL.Enums;

namespace GraphPersona.Api.Models;

public class Contact
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public ContactTypeEnum Type { get; set; }
    public string Value { get; set; } = string.Empty;
    public Guid PersonId { get; set; }
    public virtual Person Person { get; set; } = new();
}