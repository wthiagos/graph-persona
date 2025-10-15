using GraphPersona.Api.GraphQL.Inputs.Update;

namespace GraphPersona.Api.GraphQL.Types.Update;

public class UpdateAddressInputType : InputObjectType<UpdateAddressInput>
{
    protected override void Configure(IInputObjectTypeDescriptor<UpdateAddressInput> descriptor)
    {
        descriptor.Name("AddAddressInput");
        descriptor.Field(a => a.Street).Type<NonNullType<StringType>>();
        descriptor.Field(a => a.City).Type<NonNullType<StringType>>();
        descriptor.Field(a => a.ZipCode).Type<StringType>();
        descriptor.Field(a => a.Country).Type<StringType>();
    }
}
