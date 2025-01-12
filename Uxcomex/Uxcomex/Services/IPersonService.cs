using Uxcomex.Dto;

namespace Uxcomex.Services
{
	public interface IPersonService
	{
		Task<List<PersonDto>> GetAllPersons();
		Task<PersonDto> AddPerson(PersonDto personDto);
		Task<PersonDto> UpdatePerson(PersonDto personDto);
		Task<PersonDto> DeletePerson(int id);
	}
}
