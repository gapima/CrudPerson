namespace Uxcomex.Dto
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Cpf { get; set; }
        public IEnumerable<AddressDto> Addresses { get; set; }
    }
}
