using GraphPersona.Domain.Enums;

namespace GraphPersona.Domain.Entities;

public class Contact
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public ContactTypeEnum Channel { get; set; }
    public string Info { get; set; } = string.Empty;
    public Guid PersonId { get; set; }
    public virtual Person Person { get; set; } = new();
}