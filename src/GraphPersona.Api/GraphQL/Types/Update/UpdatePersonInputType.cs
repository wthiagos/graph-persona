using GraphPersona.Api.GraphQL.Inputs.Update;

namespace GraphPersona.Api.GraphQL.Types.Update;

public class UpdatePersonInputType : InputObjectType<UpdatePersonInput>
{
    protected override void Configure(IInputObjectTypeDescriptor<UpdatePersonInput> descriptor)
    {
        descriptor.Field(p => p.FullName).Type<NonNullType<StringType>>();
        descriptor.Field(p => p.BirthDate).Type<DateType>();
        descriptor.Field(p => p.Address).Type<UpdateAddressInputType>();
        descriptor.Field(p => p.Contacts).Type<ListType<UpdateContactInputType>>();
    }
}
