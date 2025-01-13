using System;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Uxcomex.Data;
using Uxcomex.Dto;
using Uxcomex.Models;

namespace Uxcomex.Services
{
	public class PersonService : IPersonService
	{
		private readonly ApplicationDbContext _context;
		private readonly IDbConnection _connection;
		public PersonService(ApplicationDbContext context, IConfiguration configuration)
		{ 
			_context = context;
            _connection = new SqlConnection(configuration.GetConnectionString("StringConnection"));
		}
		public async Task<int> AddPerson(PersonDto personDto)
		{
			try
			{
				var query =
					@"INSERT INTO Tb_Person
					VALUES (@Name, @PhoneNumber, @Cpf)";
				return  await _connection.ExecuteScalarAsync<int>(query, personDto);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
        }
        public async Task DeletePerson(int id)
		{
            try
            {
                var query = @"DELETE FROM Tb_Person WHERE id = @id";
                await _connection.ExecuteAsync(query, new {Id = id});
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
		public async Task<IEnumerable<PersonModel>> GetAllPersons()
		{

			try
			{
				var query = "SELECT * FROM Tb_Person"; 
				return await _connection.QueryAsync<PersonModel>(query);
            }
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
        public async Task<PersonModel> GetPersonById(int id)
        {
	
			try
			{
				var query = @"SELECT * FROM Tb_Person WHERE id = @id";
				return await _connection.QueryFirstOrDefaultAsync<PersonModel>(query, new {Id = id});

			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
        }
        public async Task<PersonModel> UpdatePerson(PersonDto personDto)
		{
			try
			{

				var query = @"UPDATE Tb_Person 
				SET Name = @Name,
					PhoneNumber = @PhoneNumber,
					Cpf = @Cpf 
				WHERE Id = @Id";
				var person = await _connection.QueryFirstOrDefaultAsync<PersonModel>(query, new { Id = personDto.Id });

                if (person == null)
				{
                    throw new Exception();
                }
				return person;
            }
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

	}
}
