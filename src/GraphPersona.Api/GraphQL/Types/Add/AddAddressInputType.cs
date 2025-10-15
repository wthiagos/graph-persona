using GraphPersona.Api.GraphQL.Inputs.Add;

namespace GraphPersona.Api.GraphQL.Types.Add;

public class AddAddressInputType : InputObjectType<AddAddressInput>
{
    protected override void Configure(IInputObjectTypeDescriptor<AddAddressInput> descriptor)
    {
        descriptor.Name("AddAddressInput");
        descriptor.Field(a => a.Street).Type<NonNullType<StringType>>();
        descriptor.Field(a => a.City).Type<NonNullType<StringType>>();
        descriptor.Field(a => a.ZipCode).Type<StringType>();
        descriptor.Field(a => a.Country).Type<StringType>();
    }
}
