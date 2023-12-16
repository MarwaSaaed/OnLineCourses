using System.Linq.Expressions;

namespace OCTW.Server.Repository
{
    public interface IPersonRepository<T> where T : class
    {
        Task CreateAsync(T entity);
      
        Task UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync(string Include = null);
        IEnumerable<T> GetByFilterAsync(Func<T, bool> predicate); 
       Task<T> GetByPredicateAsync(Expression<Func<T, bool>> predicate, string includeProperties = "");



    }
}
