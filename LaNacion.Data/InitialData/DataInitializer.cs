using LaNacion.Data.Persistence;
using LaNacion.Model.Entities;

namespace LaNacion.Data.InitialData
{
    public class DataInitializer
    {
        public static void SeedData(
            UnitOfWork unitOfWork)
        {
            SeedContacts(unitOfWork);
        }

        private static void SeedContacts(UnitOfWork unitOfWork)
        {
            if (unitOfWork.Contacts.GetAll().Any()) return;

            var contacts = new List<Contact>
            {
               //Add Contacts
            };

            unitOfWork.Contacts.AddRange(contacts);
            unitOfWork.Complete();
        }
    }
}
