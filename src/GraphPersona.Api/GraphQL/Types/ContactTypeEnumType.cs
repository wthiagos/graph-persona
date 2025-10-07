using GraphPersona.Api.GraphQL.Enums;

namespace GraphPersona.Api.GraphQL.Types;

public class ContactTypeEnumType : EnumType<ContactTypeEnum>
{
    protected override void Configure(IEnumTypeDescriptor<ContactTypeEnum> descriptor)
    {
        descriptor.Name("ContactType");
        descriptor.BindValuesExplicitly();
        descriptor.Value(ContactTypeEnum.Email).Name("Email");
        descriptor.Value(ContactTypeEnum.Phone).Name("Phone");
        descriptor.Value(ContactTypeEnum.WhatsApp).Name("WhatsApp");
        descriptor.Value(ContactTypeEnum.Telegram).Name("Telegram");
    }
}
