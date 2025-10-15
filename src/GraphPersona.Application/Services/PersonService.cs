using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using FluentValidation.Results;
using GraphPersona.Application.DTOs.Address;
using GraphPersona.Application.DTOs.Contact;
using GraphPersona.Application.DTOs.Person;
using GraphPersona.Domain.Entities;
using GraphPersona.Domain.Interfaces;
using HotChocolate;

namespace GraphPersona.Application.Services;

public class PersonService(
    IPersonRepository repo,
    IValidator<CreatePersonDto> createPersonInputValidator,
    IValidator<UpdatePersonDto> updatePersonInputValidator
) : IPersonService
{
    private const string ErrorCodeContactNotFound = "CONTACT_NOT_FOUND";
    private const string ErrorCodeAddresstNotFound = "ADDRESS_NOT_FOUND";
    private const string ErrorCodePersonNotFound = "PERSON_NOT_FOUND";
    private const string ErrorMessagePersonNotFound = "Person not found.";

    public async Task<IEnumerable<PersonDto>> GetAllAsync()
    {
        var persons = await repo.GetAllAsync();
        return persons
            .Select(MapToDto);
    }

    public async Task<PersonDto?> GetByIdAsync(Guid id)
    {
        var person = await repo.GetByIdAsync(id);

        if (person is null)
            ThrowPersonNotFoundException();

        return MapToDto(person);
    }

    public async Task<PersonDto> AddAsync(CreatePersonDto createPersonDto)
    {
        var validationResult = await createPersonInputValidator.ValidateAsync(createPersonDto);
        if (!validationResult.IsValid)
        {
            ThrowValidationErrors(validationResult);
        }

        var person = await repo.AddAsync(createPersonDto.ToEntity());
        return MapToDto(person);
    }

    public async Task<PersonDto> UpdateAsync(Guid id, UpdatePersonDto updatePersonDto)
    {
        var personToUpdate = await repo.GetByIdAsync(id);
        if (personToUpdate is null)
        {
            ThrowPersonNotFoundException();
        }

        var contactErrors = ValidateContactsExist(personToUpdate, updatePersonDto.Contacts);
        if (contactErrors.Count > 0)
        {
            ThrowValidationErrors(contactErrors);
        }
        
        var addressErrors = ValidateAddressExist(personToUpdate, updatePersonDto.Address);
        if (addressErrors.Count > 0)
        {
            ThrowValidationErrors(addressErrors);
        }

        var validationResult = await updatePersonInputValidator.ValidateAsync(updatePersonDto);
        if (!validationResult.IsValid)
        {
            ThrowValidationErrors(validationResult);
        }

        UpdatePersonProperties(personToUpdate, updatePersonDto);
        UpdateAddress(personToUpdate, updatePersonDto.Address);
        UpdateContacts(personToUpdate, updatePersonDto.Contacts);

        var person = await repo.UpdateAsync(personToUpdate);
        return MapToDto(person);
    }

    private static List<IError> ValidateContactsExist(Person person, List<UpdateContactDto>? updateContactDtos)
    {
        var errors = new List<IError>();

        if (updateContactDtos is null || person.Contacts is null)
        {
            return errors;
        }

        foreach (var updateContactDto in updateContactDtos)
        {
            var contactExists = person.Contacts.Any(c => c.Id == updateContactDto.Id);
            if (!contactExists)
            {
                errors.Add(BuildError($"Contact with ID {updateContactDto.Id} not found.", ErrorCodeContactNotFound));
            }
        }

        return errors;
    }

    private static List<IError> ValidateAddressExist(Person person, UpdateAddressDto? updateAddressDto)
    {
        var errors = new List<IError>();

        if (updateAddressDto is null || person.Address is null)
        {
            return errors;
        }

        var addressExists = person.Address.Id == updateAddressDto.Id;
        if (!addressExists)
        {
            errors.Add(BuildError($"Address with ID {updateAddressDto.Id} not found.", ErrorCodeAddresstNotFound));
        }

        return errors;
    }

    private static void UpdatePersonProperties(Person person, UpdatePersonDto updatePersonDto)
    {
        if (updatePersonDto.FullName is not null)
        {
            person.FullName = updatePersonDto.FullName;
        }

        if (updatePersonDto.BirthDate is not null)
        {
            person.BirthDate = updatePersonDto.BirthDate.Value;
        }
    }

    private static void UpdateAddress(Person person, UpdateAddressDto? updateAddressDto)
    {
        if (updateAddressDto is null)
        {
            return;
        }

        if (person.Address is null)
        {
            person.Address = updateAddressDto.ToEntity();
            return;
        }

        if (updateAddressDto.City is not null)
            person.Address.City = updateAddressDto.City;
        if (updateAddressDto.State is not null)
            person.Address.State = updateAddressDto.State;
        if (updateAddressDto.Country is not null)
            person.Address.Country = updateAddressDto.Country;
        if (updateAddressDto.ZipCode is not null)
            person.Address.ZipCode = updateAddressDto.ZipCode;
        if (updateAddressDto.Street is not null)
            person.Address.Street = updateAddressDto.Street;
    }

    private static void UpdateContacts(Person person, List<UpdateContactDto>? contactsInput)
    {
        if (contactsInput is null)
        {
            return;
        }

        if (person.Contacts is null)
        {
            person.Contacts = contactsInput
                .Select(c => c.ToEntity())
                .Where(c => c is not null)
                .ToList()!;
            return;
        }

        foreach (var updateContactInput in contactsInput)
        {
            var contact = person.Contacts.FirstOrDefault(c => c.Id == updateContactInput.Id);
            if (contact is null)
            {
                continue;
            }

            if (updateContactInput.Channel is not null)
                contact.Channel = updateContactInput.Channel.Value;
            if (updateContactInput.Info is not null)
                contact.Info = updateContactInput.Info;
        }
    }

    private static IError BuildError(string message, string code)
    {
        return ErrorBuilder.New()
            .SetMessage(message)
            .SetCode(code)
            .Build();
    }

    private static void ThrowValidationErrors(ValidationResult validationResult)
    {
        var errors = validationResult.Errors
            .Select(failure => BuildError(failure.ErrorMessage, failure.ErrorCode))
            .ToList();

        throw new GraphQLException(errors);
    }

    private static void ThrowValidationErrors(List<IError> errors)
    {
        throw new GraphQLException(errors);
    }

    [DoesNotReturn]
    private static void ThrowPersonNotFoundException()
    {
        throw new GraphQLException(BuildError(ErrorMessagePersonNotFound, ErrorCodePersonNotFound));
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var person = await repo.GetByIdAsync(id);
        if (person is null)
        {
            ThrowPersonNotFoundException();
        }

        return await repo.DeleteAsync(id);
    }

    private static PersonDto MapToDto(Person person)
    {
        return new PersonDto(
            person.Id,
            person.FullName,
            person.BirthDate,
            person.Address is not null
                ? new AddressDto(
                    person.Address.Id,
                    person.Address.Street,
                    person.Address.City,
                    person.Address.ZipCode,
                    person.Address.State,
                    person.Address.Country
                )
                : null,
            person.Contacts
                ?.Select(c => new ContactDto(
                        c.Id,
                        c.Channel,
                        c.Info
                    )
                )
                .ToList()
        );
    }
}