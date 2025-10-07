using GraphPersona.Api.Models;

namespace GraphPersona.Api.GraphQL.Types;

public class AddressType: ObjectType<Address>
{
    protected override void Configure(IObjectTypeDescriptor<Address> descriptor)
    {
        descriptor.Field(p => p.Id).Type<NonNullType<UuidType>>();
        descriptor.Field(p => p.Street).Type<NonNullType<StringType>>();
        descriptor.Field(p => p.City).Type<NonNullType<StringType>>();
        descriptor.Field(p => p.State).Type<NonNullType<StringType>>();
        descriptor.Field(p => p.Country).Type<NonNullType<StringType>>();
        descriptor.Field(p => p.ZipCode).Type<NonNullType<StringType>>();
    }
}