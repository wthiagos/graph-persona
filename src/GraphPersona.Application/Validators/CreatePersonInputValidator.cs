using FluentValidation;
using GraphPersona.Application.DTOs.Address;
using GraphPersona.Application.DTOs.Contact;
using GraphPersona.Application.DTOs.Person;

namespace GraphPersona.Application.Validators;

public class CreatePersonInputValidator : AbstractValidator<CreatePersonDto>
{
    public CreatePersonInputValidator(
        IValidator<CreateAddressDto> addressValidator,
        IValidator<CreateContactDto> contactValidator
    )
    {
        RuleFor(x => x.FullName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Full name is required.")
            .WithErrorCode("INVALID_FULLNAME")
            .MaximumLength(100)
            .WithMessage("Full name cannot be longer than 100 characters.")
            .WithErrorCode("MAX_LENGTH_FULLNAME");

        RuleFor(x => x.BirthDate)
            .NotEmpty()
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
            .WithMessage("Birth date cannot be in the future.")
            .WithErrorCode("INVALID_BIRTHDATE");

        When(x => x.Address is not null, () =>
        {
            RuleFor(x => x.Address!)
                .SetValidator(addressValidator);
        });

        When(x => x.Contacts is not null, () =>
        {
            RuleForEach(x => x.Contacts!)
                .SetValidator(contactValidator);
        });
    }
}