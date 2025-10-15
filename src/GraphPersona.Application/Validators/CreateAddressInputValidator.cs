using FluentValidation;
using GraphPersona.Application.DTOs.Address;

namespace GraphPersona.Application.Validators;

public class CreateAddressInputValidator: AbstractValidator<CreateAddressDto>
{
    public CreateAddressInputValidator()
    {
        RuleFor(x => x.City)
            .NotEmpty()
            .WithMessage("Address City is required.")
            .WithErrorCode("INVALID_ADDRESS_CITY")
            .MaximumLength(100)
            .WithMessage("Address City cannot be longer than 100 characters.")
            .WithErrorCode("MAX_LENGTH_ADDRESS_CITY");
        
        RuleFor(x => x.Country)
            .NotEmpty()
            .WithMessage("Address Country is required.")
            .WithErrorCode("INVALID_ADDRESS_COUNTRY")
            .MaximumLength(100)
            .WithMessage("Address Country cannot be longer than 100 characters.")
            .WithErrorCode("MAX_LENGTH_ADDRESS_COUNTRY");
        
        RuleFor(x => x.State)
            .NotEmpty()
            .WithMessage("Address State is required.")
            .WithErrorCode("INVALID_ADDRESS_STATE")
            .MaximumLength(100)
            .WithMessage("Address State cannot be longer than 100 characters.")
            .WithErrorCode("MAX_LENGTH_ADDRESS_STATE");
        
        RuleFor(x => x.Street)
            .NotEmpty()
            .WithMessage("Address Street is required.")
            .WithErrorCode("INVALID_ADDRESS_STREET")
            .MaximumLength(100)
            .WithMessage("Address Street cannot be longer than 100 characters.")
            .WithErrorCode("MAX_LENGTH_ADDRESS_STREET");
        
        RuleFor(x => x.ZipCode)
            .NotEmpty()
            .WithMessage("Address ZipCode is required.")
            .WithErrorCode("INVALID_ADDRESS_ZIPCODE")
            .MaximumLength(100)
            .WithMessage("Address ZipCode cannot be longer than 100 characters.")
            .WithErrorCode("MAX_LENGTH_ADDRESS_ZIPCODE");
    }
}