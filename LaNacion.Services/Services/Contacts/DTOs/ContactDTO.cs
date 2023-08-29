namespace LaNacion.Services.Services.Contacts.DTOs
{
    public class ContactDTO
    {
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public int CompanyId { get; set; }

    }
}