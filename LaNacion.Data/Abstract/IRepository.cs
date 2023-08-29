using System.Linq.Expressions;

namespace LaNacion.Data.Abstract
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void AddRange(IEnumerable<T> entities);
        void Add(T entity);

        void Remove(T entity);
    }
}