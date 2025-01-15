using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Uxcomex.Data;
using Uxcomex.Dto;
using Uxcomex.Models;

namespace Uxcomex.Repositories.Person
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IDbConnection _connection;
        public PersonRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _connection = new SqlConnection(configuration.GetConnectionString("StringConnection"));
        }
        public async Task<PersonModel> CreatePerson(PersonDto personDto)
        {
            try
            {
                var query = @"
                    INSERT INTO Tb_Person
                    OUTPUT INSERTED.Id, INSERTED.Name, INSERTED.PhoneNumber, INSERTED.Cpf
                    VALUES (@Name, @PhoneNumber, @Cpf);";
                var person = await _connection.QuerySingleOrDefaultAsync<PersonModel>(query, personDto);
                if (person == null)
                    throw new Exception();
                return person;
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
                await _connection.ExecuteAsync(query, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task DeleteAddressFromPerson(int personId)
        {
            try
            {
                var query = @"DELETE FROM Tb_Address WHERE PersonId = @personId";
                await _connection.ExecuteAsync(query, new { PersonId = personId });
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
                var query = "SELECT * FROM Tb_Person ORDER BY Id Desc";
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
                var person = await _connection.QueryFirstOrDefaultAsync<PersonModel>(query, new { Id = id });

                if (person == null)
                    throw new Exception();
                var queryAdrees = @"SELECT * FROM Tb_Address WHERE PersonId = @id ORDER By Id Desc";
                var address = await _connection.QueryAsync<AddressModel>(queryAdrees, new { id = id });
                person.Addresses = address;
                return person;
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

                var query = @"
                    UPDATE Tb_Person 
                    SET Name = @Name,
                        PhoneNumber = @PhoneNumber,
                        Cpf = @Cpf 
                    OUTPUT INSERTED.Id, INSERTED.Name, INSERTED.PhoneNumber, INSERTED.Cpf
                    WHERE Id = @Id";
                var person = await _connection.QueryFirstOrDefaultAsync<PersonModel>(query, personDto);

                if (person == null)
                    throw new Exception();
                return person;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

