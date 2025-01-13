using Uxcomex.Dto;
using Uxcomex.Models;

namespace Uxcomex.Services
{
	public interface IPersonService
	{
		Task<IEnumerable<PersonModel>> GetAllPersons(); 
		Task<PersonModel> GetPersonById(int id);
        Task<int> AddPerson(PersonDto personDto);
		Task<PersonModel> UpdatePerson(PersonDto personDto);
		Task DeletePerson(int id);
	}
}

