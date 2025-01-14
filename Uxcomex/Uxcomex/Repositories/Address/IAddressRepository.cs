using Uxcomex.Dto;
using Uxcomex.Models;

namespace Uxcomex.Repositories.Address
{
    public interface IAddressRepository
    {
        Task<AddressModel> GetAddressById(int id);
        Task<IEnumerable<AddressModel>> GetAllAddressByPersonId(int personId);
        Task CreateAddress(AddressDto addressDto);
        Task<AddressModel> UpdateAddress(AddressDto address);
        Task DeleteAddress(int id);
    }
}
