using Uxcomex.Dto;
using Uxcomex.Models;
using Uxcomex.Repositories.Address;

namespace Uxcomex.Services
{
    public class AddressService
    {
        private readonly IAddressRepository _addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task  CreateAddress(AddressDto addressDto)
        {
            await _addressRepository.CreateAddress(addressDto);
        }
        public async Task DeleteAddress(int id)
        {
            await _addressRepository.DeleteAddress(id);
        }
        public async Task<IEnumerable<AddressModel>> GetAllAddressByPersonId(int personId)
        {
            return await _addressRepository.GetAllAddressByPersonId(personId);
        }
        public async Task<AddressModel> GetAddressById(int id)
        {
            return await _addressRepository.GetAddressById(id);
        }
        public async Task<AddressModel> UpdateAddress(AddressDto addressDto)
        {
            return await _addressRepository.UpdateAddress(addressDto);
        }
    }
}
