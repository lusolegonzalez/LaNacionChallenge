using AutoMapper;
using LaNacion.Data.Abstract;
using LaNacion.Services.Services.Contacts;

namespace LaNacion.Services.Services
{
    public class Services : IServices
    {
        public IContactsService ContactsService { get; }

        public Services(IUnitOfWork unitOfWork, IMapper mapper)
        {
            ContactsService = new ContactsService(unitOfWork, mapper);
        }
    }
}