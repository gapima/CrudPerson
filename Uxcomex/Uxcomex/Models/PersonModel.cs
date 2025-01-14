
namespace Uxcomex.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Cpf { get; set; }
        public IEnumerable<AddressModel> Addresses { get; set; }
    }
};