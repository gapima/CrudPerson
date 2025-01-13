namespace Uxcomex.Dto
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Cpf { get; set; }
        public List<AddressDto> Addresses { get; set; } = new List<AddressDto>();
    }
}
