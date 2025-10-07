namespace GraphPersona.Api.Models;

public class Person
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FullName { get; set; } = string.Empty;
    public DateOnly BirthDate { get; set; }
    public Guid? AddressId { get; set; }
    public Address? Address { get; set; }
    public List<Contact>? Contacts { get; set; } = [];
}