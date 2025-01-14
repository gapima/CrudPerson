using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Uxcomex.Data;
using Uxcomex.Dto;
using Uxcomex.Models;

namespace Uxcomex.Repositories.Address
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IDbConnection _connection;
        public  AddressRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _connection = new SqlConnection(configuration.GetConnectionString("StringConnection"));
        }
        public async Task CreateAddress(AddressDto addressDto)
        {
            try
            {
                var query = @"INSERT INTO Tb_Address
                VALUES (@StreetAddress, @Zipcode, @City, @State, @PersonId)";
                await _connection.ExecuteAsync(query, addressDto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAddress(int id)
        {
            try
            {
                var query = @"DELETE FROM Tb_Address WHERE id = @id";
                await _connection.ExecuteAsync(query, new {Id = id});
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AddressModel> GetAddressById(int id)
        {
            try
            {
                var query = @"SELECT * FROM Tb_Address WHERE id = @id";
                var address =  await _connection.QueryFirstOrDefaultAsync<AddressModel>(query, new { Id = id});
                if (address == null)
                    throw new Exception();
                return address;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<AddressModel>> GetAllAddressByPersonId(int personId)
        {
            try
            {
                var query = @"SELECT * FROM Tb_Address WHERE PersonId = @PersonId";
                var address = await _connection.QueryAsync<AddressModel>(query, new {personId =  personId});
                if (address == null)
                    throw new Exception();
                return address;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AddressModel> UpdateAddress(AddressDto addressDto)
        {
            try
            {
                var query = @"UPDATE Tb_Address 
				SET StreetAddress = @StreetAddress,
					Zipcode = @Zipcode,
					City = @City,
					State = @State
				WHERE Id = @Id and PersonId = @PersonID";
                var address = await _connection.QueryFirstOrDefaultAsync<AddressModel>(query, new {  id = addressDto.id, personId = addressDto.PersonId});
                if (address == null)
                    throw new Exception();
                return address;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
