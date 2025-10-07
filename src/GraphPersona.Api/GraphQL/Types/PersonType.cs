using GraphPersona.Api.Models;

namespace GraphPersona.Api.GraphQL.Types;

public class PersonType : ObjectType<Person>
{
    protected override void Configure(IObjectTypeDescriptor<Person> descriptor)
    {
        descriptor.Field(p => p.Id).Type<NonNullType<UuidType>>();
        descriptor.Field(p => p.FullName).Type<NonNullType<StringType>>();
        descriptor.Field(p => p.BirthDate).Type<DateType>();
        descriptor.Field(p => p.Contacts).Type<ListType<ContactType>>();
        descriptor.Field(p => p.Address).Type<AddressType>();
    }
}
