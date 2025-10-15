using FluentValidation;
using GraphPersona.Application.DTOs.Contact;

namespace GraphPersona.Application.Validators;

public class CreateContactInputValidator: AbstractValidator<CreateContactDto>
{
    public CreateContactInputValidator()
    {
        RuleFor(x => x.Channel)
            .IsInEnum()
            .WithMessage("Contact Channel must be a valid value.")
            .WithErrorCode("INVALID_CONTACT_CHANNEL");
        
        RuleFor(x => x.Info)
            .NotEmpty()
            .WithMessage("Contact Info is required.")
            .WithErrorCode("INVALID_CONTACT_INFO")
            .MaximumLength(100)
            .WithMessage("Contact Info cannot be longer than 100 characters.")
            .WithErrorCode("MAX_LENGTH_CONTACT_INFO");
    }
}