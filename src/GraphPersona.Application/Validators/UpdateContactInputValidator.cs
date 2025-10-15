using FluentValidation;
using GraphPersona.Application.DTOs.Contact;

namespace GraphPersona.Application.Validators;

public class UpdateContactInputValidator: AbstractValidator<UpdateContactDto>
{
    public UpdateContactInputValidator()
    {
        When(x => x.Channel.HasValue, () =>
        {
            RuleFor(x => x.Channel)
                .IsInEnum()
                .WithMessage("Contact Channel must be a valid value.")
                .WithErrorCode("INVALID_CONTACT_CHANNEL");
        });
        
        RuleFor(x => x.Info)
            .MaximumLength(100)
            .WithMessage("Contact Info cannot be longer than 100 characters.")
            .WithErrorCode("MAX_LENGTH_CONTACT_INFO");
    }
}