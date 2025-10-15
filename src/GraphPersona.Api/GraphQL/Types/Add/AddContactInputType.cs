using GraphPersona.Api.GraphQL.Inputs.Add;

namespace GraphPersona.Api.GraphQL.Types.Add;

public class AddContactInputType : InputObjectType<AddContactInput>
{
    protected override void Configure(IInputObjectTypeDescriptor<AddContactInput> descriptor)
    {
        descriptor.Name("AddContactInput");
        descriptor.Field(c => c.Channel).Type<NonNullType<ContactTypeEnumType>>();
        descriptor.Field(c => c.Info).Type<NonNullType<StringType>>();
    }
}
