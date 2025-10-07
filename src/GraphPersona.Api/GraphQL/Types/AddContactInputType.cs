using GraphPersona.Api.GraphQL.Inputs;

namespace GraphPersona.Api.GraphQL.Types;

public class AddContactInputType : InputObjectType<AddContactInput>
{
    protected override void Configure(IInputObjectTypeDescriptor<AddContactInput> descriptor)
    {
        descriptor.Name("AddContactInput");
        descriptor.Field(c => c.Type).Type<NonNullType<ContactTypeEnumType>>();
        descriptor.Field(c => c.Value).Type<NonNullType<StringType>>();
    }
}
