using AutoMapper;
using LaNacion.Data.Abstract;
using LaNacion.Model.Entities;
using LaNacion.Services.Services.Contacts.DTOs;
using LaNacion.Services.Services.Contacts.Exceptions;

namespace LaNacion.Services.Services.Contacts
{
    public class ContactsService : IContactsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Create(Contact created)
        {
            //Throw exception if contact email already exists
            if (_unitOfWork.Contacts.GetAll().Any(x => x.Email.Trim().ToLower().Equals(created.Email.Trim().ToLower())))
                throw new DuplicatedContactException("Contact already registered");

            try
            {
                _unitOfWork.Contacts.Add(created);
                _unitOfWork.Complete();
            }
            catch (Exception)
            {
                throw new CreateContactException("Something went wrong while saving");
            }
        }

        public void Update(int id, ContactDTO updated)
        {
            var contact = _unitOfWork.Contacts.Get(id);

            //Throw exception if contact doesn't exists
            if (contact == null)
                throw new ContactNotFoundException("Contact doesn't exists");
            try
            {
                var contactBefore = new Contact();

                contact.Birthdate = contactBefore.Birthdate;
                contact.Name = contactBefore.Name;
                contact.Image = contactBefore.Image;
                contact.CompanyId = contactBefore.CompanyId;

                _unitOfWork.Complete();
            }
            catch (Exception)
            {
                throw new UpdateContactException("Something went wrong while updating");
            }
        }

        public void Delete(int id)
        {
            try
            {
                var toBeDeleted = _unitOfWork.Contacts.Get(id);

                //Throw exception if contact doesn't exists
                if (toBeDeleted == null)
                    throw new ContactNotFoundException("Contact doesn't exists");

                _unitOfWork.Contacts.Remove(toBeDeleted);
                _unitOfWork.Complete();
            }
            catch (Exception)
            {
                throw new DeleteContactException("Something went wrong while deleting");
            }
        }

        public Contact GetById(int id)
        {
            var toReturn = _unitOfWork.Contacts.Get(id);

            if (toReturn == null)
                throw new ContactNotFoundException("Contact doesn't exists");

            return toReturn;
        }

        public IEnumerable<Contact> GetByCityOrState(string cityOrState)
        {
            var toReturn = _unitOfWork.Contacts.GetByCityOrState(cityOrState) ?? throw new ContactNotFoundException("Contact doesn't exists");
            return toReturn;
        }

        public Contact GetByEmail(string email)
        {
            var toReturn = _unitOfWork.Contacts.GetByEmail(email) ?? throw new ContactNotFoundException("Contact doesn't exists");
            return toReturn;
        }

        public IEnumerable<Contact> GetByPhoneNumber(string phoneNumber)
        {
            var toReturn = _unitOfWork.Contacts.GetByPhoneNumber(phoneNumber);
            return !toReturn.Any() ? throw new ContactNotFoundException("Contacts doesn't exists") : toReturn;
        }

        public IEnumerable<Contact> GetAll()
        {
            var toReturn = _unitOfWork.Contacts.GetAll();
            return !toReturn.Any() ? throw new ContactNotFoundException("Contacts doesn't exists") : toReturn;
        }

    }
}