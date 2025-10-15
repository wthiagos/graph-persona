using GraphPersona.Api.GraphQL.Inputs.Update;

namespace GraphPersona.Api.GraphQL.Types.Update;

public class UpdateContactInputType : InputObjectType<UpdateContactInput>
{
    protected override void Configure(IInputObjectTypeDescriptor<UpdateContactInput> descriptor)
    {
        descriptor.Name("AddContactInput");
        descriptor.Field(c => c.Channel).Type<NonNullType<ContactTypeEnumType>>();
        descriptor.Field(c => c.Info).Type<NonNullType<StringType>>();
    }
}
