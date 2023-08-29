namespace LaNacion.Model.Entities
{
    public class Contact : EntityBase
    {
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public int AddressId { get; set; }
        public int CompanyId { get; set; }

        public ContactAddress Address { get; set; }
        public virtual Company Company { get; set; }
        public virtual IEnumerable<PhoneNumber> PhoneNumbers { get; set; }
    }
}