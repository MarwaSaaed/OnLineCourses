using System.Linq.Expressions;

namespace OCTW.Server.Repository
{
    public interface IPersonRepository<T> where T : class
    {
        Task CreateAsync(T entity);
      
        Task UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByFilterAsync(Func<T, bool> predicate, string include = null); 
       Task<T> GetByPredicateAsync(Expression<Func<T, bool>> predicate, string includeProperties = "");



    }
}
