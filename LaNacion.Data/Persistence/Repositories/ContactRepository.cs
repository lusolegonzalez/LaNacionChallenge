using LaNacion.Data.Abstract.Repositories;
using LaNacion.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace LaNacion.Data.Persistence.Repositories
{

    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ApplicationContext ApplicationContext => (ApplicationContext)Context;

        public ContactRepository(ApplicationContext context) : base(context) { }

        public IEnumerable<Contact> GetByPhoneNumber(string phoneNumber)
        {
            return ApplicationContext.Contacts
                .Include(x => x.PhoneNumbers)
                .Where(x => x.PhoneNumbers.Select(y => y.Number).Contains(phoneNumber))
                .ToList();
        }

        public Contact GetByEmail(string email)
        {
            return ApplicationContext.Contacts.First(x => x.Email == email);
        }

        public IEnumerable<Contact> GetByCityOrState(string cityOrState)
        {
            return ApplicationContext.Contacts
                .Include(x => x.Address)
                .Where(x => x.Address.City == cityOrState || x.Address.State == cityOrState)
                .ToList();
        }

    }
}
