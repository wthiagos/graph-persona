using GraphPersona.Api.Models;

namespace GraphPersona.Api.GraphQL.Types;

public class ContactType: ObjectType<Contact>
{
    protected override void Configure(IObjectTypeDescriptor<Contact> descriptor)
    {
        descriptor.Field(p => p.Id).Type<NonNullType<UuidType>>();
        descriptor.Field(p => p.Type).Type<NonNullType<ContactTypeEnumType>>();
        descriptor.Field(p => p.Value).Type<StringType>();
        descriptor.Field(p => p.PersonId).Type<NonNullType<UuidType>>();
    }
}