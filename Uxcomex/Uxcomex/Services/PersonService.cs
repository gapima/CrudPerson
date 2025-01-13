using System;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Uxcomex.Data;
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
		public async Task AddPerson(PersonDto personDto)
		{
			await _personRepository.AddPerson(personDto);
        }
        public async Task DeletePerson(int id)
		{
            await _personRepository.DeletePerson(id);
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
