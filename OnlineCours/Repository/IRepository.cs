using OnlineCours.Models;

namespace OCTW.Server.Repository
{
	public interface IRepository<T> where T : BaseClase
	{
		List<T> GetAllByFilter(Func<T, bool> predicate);
		Task<T> GetById(int Id);
		Task<List<T>> GetAllAsync(string? v=null);
		Task CreateAsync(T entity);
		Task UpdateAsync(T entity);

		Task Delete(T entity);
	}
}
