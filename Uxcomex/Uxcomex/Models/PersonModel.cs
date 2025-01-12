
namespace Uxcomex.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  int PhoneNumber { get; set; }
        public string Cpf { get; set; }
        public ICollection<AddressModel> Addresses { get; set; } = new List<AddressModel>();
    }
};