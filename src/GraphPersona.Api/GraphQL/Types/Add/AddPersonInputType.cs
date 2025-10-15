using GraphPersona.Api.GraphQL.Inputs.Add;

namespace GraphPersona.Api.GraphQL.Types.Add;

public class AddPersonInputType : InputObjectType<AddPersonInput>
{
    protected override void Configure(IInputObjectTypeDescriptor<AddPersonInput> descriptor)
    {
        descriptor.Field(p => p.FullName).Type<NonNullType<StringType>>();
        descriptor.Field(p => p.BirthDate).Type<DateType>();
        descriptor.Field(p => p.Address).Type<AddAddressInputType>();
        descriptor.Field(p => p.Contacts).Type<ListType<AddContactInputType>>();
    }
}
