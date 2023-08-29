using LaNacion.Data.Abstract;
using LaNacion.Data.Abstract.Repositories;
using LaNacion.Data.Persistence.Repositories;

namespace LaNacion.Data.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public IContactRepository Contacts { get; }

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Contacts = new ContactRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public Task<int> CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}