using LaNacion.Services.Services.Contacts;

namespace LaNacion.Services
{
    public interface IServices
    {
        IContactsService ContactsService { get; }
    }
}
