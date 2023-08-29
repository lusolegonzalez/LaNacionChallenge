using LaNacion.Data.Abstract.Repositories;

namespace LaNacion.Data.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
		IContactRepository Contacts { get; }
        int Complete();
        Task<int> CompleteAsync();
    }
}