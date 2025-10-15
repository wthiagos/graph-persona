using GraphPersona.Application.DTOs.Person;

namespace GraphPersona.Application.Services;

public interface IPersonService
{
    Task<IEnumerable<PersonDto>> GetAllAsync();
    Task<PersonDto?> GetByIdAsync(Guid id);
    Task<PersonDto> AddAsync(CreatePersonDto person);
    Task<PersonDto> UpdateAsync(Guid id, UpdatePersonDto person);
    Task<bool> DeleteAsync(Guid id);
}