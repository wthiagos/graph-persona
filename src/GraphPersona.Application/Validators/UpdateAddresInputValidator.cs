using FluentValidation;
using GraphPersona.Application.DTOs.Address;

namespace GraphPersona.Application.Validators;


public class UpdateAddressInputValidator: AbstractValidator<UpdateAddressDto>
{
    public UpdateAddressInputValidator()
    {
        RuleFor(x => x.City)
            .MaximumLength(100)
            .WithMessage("Address City cannot be longer than 100 characters.")
            .WithErrorCode("MAX_LENGTH_ADDRESS_CITY");
        
        RuleFor(x => x.Country)
            .MaximumLength(100)
            .WithMessage("Address Country cannot be longer than 100 characters.")
            .WithErrorCode("MAX_LENGTH_ADDRESS_COUNTRY");
        
        RuleFor(x => x.State)
            .MaximumLength(100)
            .WithMessage("Address State cannot be longer than 100 characters.")
            .WithErrorCode("MAX_LENGTH_ADDRESS_STATE");
        
        RuleFor(x => x.Street)
            .MaximumLength(100)
            .WithMessage("Address Street cannot be longer than 100 characters.")
            .WithErrorCode("MAX_LENGTH_ADDRESS_STREET");
        
        RuleFor(x => x.ZipCode)
            .MaximumLength(100)
            .WithMessage("Address ZipCode cannot be longer than 100 characters.")
            .WithErrorCode("MAX_LENGTH_ADDRESS_ZIPCODE");
    }
}