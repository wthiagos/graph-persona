using FluentValidation;
using GraphPersona.Application.DTOs.Address;
using GraphPersona.Application.DTOs.Contact;
using GraphPersona.Application.DTOs.Person;

namespace GraphPersona.Application.Validators;

public class UpdatePersonInputValidator : AbstractValidator<UpdatePersonDto>
{
    public UpdatePersonInputValidator(
        IValidator<UpdateAddressDto> addressValidator,
        IValidator<UpdateContactDto> contactValidator
    )
    {
        When(x => x.BirthDate.HasValue, () =>
        {
            RuleFor(x => x.BirthDate!.Value)
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
                .WithMessage("Birth date cannot be in the future.")
                .WithErrorCode("INVALID_BIRTHDATE");
        });

        RuleFor(x => x.FullName)
            .MaximumLength(100)
            .WithMessage("Full name cannot be longer than 100 characters.")
            .WithErrorCode("MAX_LENGTH_FULLNAME");

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