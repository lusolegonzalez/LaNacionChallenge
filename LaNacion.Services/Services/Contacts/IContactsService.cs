using LaNacion.Model.Entities;
using LaNacion.Services.Services.Contacts.DTOs;

namespace LaNacion.Services.Services.Contacts
{
    public interface IContactsService
    {
        void Create(Contact created);
        void Delete(int id);
        void Update(int id, ContactDTO updated);
        Contact GetById(int id);
        IEnumerable<Contact> GetByCityOrState(string cityOrState);
        Contact GetByEmail(string email);
        IEnumerable<Contact> GetByPhoneNumber(string phoneNumber);
        IEnumerable<Contact> GetAll();

    }
}