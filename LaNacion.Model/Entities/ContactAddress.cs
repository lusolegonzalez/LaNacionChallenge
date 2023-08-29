namespace LaNacion.Model.Entities
{
    public class ContactAddress
    {
        public int ContactId { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public virtual Contact Contact { get; set; }

    }
}