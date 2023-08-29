using LaNacion.Model.Entities;

namespace LaNacion.Data.Abstract.Repositories
{
    public interface IContactRepository : IRepository<Contact>
    {
        Contact GetByEmail(string Email);
        IEnumerable<Contact> GetByPhoneNumber(string phoneNumber);
        IEnumerable<Contact> GetByCityOrState(string cityOrState);
    }
}
