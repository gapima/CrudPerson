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
        public AddressRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _connection = new SqlConnection(configuration.GetConnectionString("StringConnection"));
        }
        public async Task<AddressModel> CreateAddress(AddressDto addressDto)
        {
            try
            {
                var query = @"INSERT INTO Tb_Address
                OUTPUT INSERTED.Id, INSERTED.StreetAddress, INSERTED.Zipcode, INSERTED.City, INSERTED.State, INSERTED.PersonId
                VALUES (@StreetAddress, @Zipcode, @City, @State, @PersonId)";
                var address = await _connection.QueryFirstOrDefaultAsync<AddressModel>(query, addressDto);
                if (address == null)
                    throw new Exception();
                return address;
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
                await _connection.ExecuteAsync(query, new { Id = id });
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
                var address = await _connection.QueryFirstOrDefaultAsync<AddressModel>(query, new { Id = id });
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
                var query = @"SELECT * FROM Tb_Address WHERE PersonId = @PersonId ORDER BY Id Desc";
                var address = await _connection.QueryAsync<AddressModel>(query, new { personId = personId });
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
                 OUTPUT INSERTED.Id, INSERTED.StreetAddress, INSERTED.Zipcode, INSERTED.City, INSERTED.State, INSERTED.PersonId
				WHERE Id = @Id";
                var address = await _connection.QueryFirstOrDefaultAsync<AddressModel>(query, addressDto);
                if (address == null)
                    throw new Exception();
                return address;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //public async Task<ActionResult> BuscarEndereco(string cep)
        //{
        //    if (string.IsNullOrEmpty(cep))
        //    {
        //        return Json(new { success = false, message = "CEP não informado." });
        //    }

        //    try
        //    {
        //        var response = await _httpClient.GetAsync($"https://api.exemplo.com/cep/{cep}");
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var endereco = await response.Content.ReadAsAsync<Endereco>();
        //            return Json(new { success = true, endereco });
        //        }
        //        else
        //        {
        //            return Json(new { success = false, message = "CEP não encontrado." });
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return Json(new { success = false, message = "Erro ao consultar a API." });
        //    }
        //}
    }
}
