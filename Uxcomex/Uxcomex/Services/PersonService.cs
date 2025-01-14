using Uxcomex.Dto;
using Uxcomex.Models;
using Uxcomex.Repositories.Person;

namespace Uxcomex.Services
{
    public class PersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<PersonModel> CreatePerson(PersonDto personDto)
        {
            return await _personRepository.CreatePerson(personDto);
        }
        public async Task DeletePerson(int id)
        {
            await _personRepository.DeletePerson(id);
        }
        public async Task DeleteAddressFromPerson(int personId)
        {
            await _personRepository.DeleteAddressFromPerson(personId);
        }
        public async Task<IEnumerable<PersonModel>> GetAllPersons()
        {
            return await _personRepository.GetAllPersons();
        }
        public async Task<PersonModel> GetPersonById(int id)
        {
            return await _personRepository.GetPersonById(id);
        }
        public async Task<PersonModel> UpdatePerson(PersonDto personDto)
        {
            return await _personRepository.UpdatePerson(personDto);
        }

    }
}
