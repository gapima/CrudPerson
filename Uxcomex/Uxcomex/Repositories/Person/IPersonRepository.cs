using Uxcomex.Dto;
using Uxcomex.Models;

namespace Uxcomex.Repositories.Person
{
    public interface IPersonRepository
    {
        Task<IEnumerable<PersonModel>> GetAllPersons();
        Task<PersonModel> GetPersonById(int id);
        Task<PersonModel> CreatePerson(PersonDto personDto);
        Task<PersonModel> UpdatePerson(PersonDto personDto);
        Task DeletePerson(int id);
    }
}
 