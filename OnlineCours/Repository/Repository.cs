using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using OnlineCours.Models;

namespace OCTW.Server.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseClase
    {
		private readonly Context _context;

		public Repository(Context context)
		{
			this._context=context;
		}

		public async Task CreateAsync(T entity)
		{
			 _context.Set<T>().Add(entity);
			await _context.SaveChangesAsync();
		}


		public async Task<List<T>> GetAllAsync(string[] include = null)
		{
			IQueryable<T> Query = _context.Set<T>().Where(x => x.IsDeleted == false);
            if (include!=null)
			{
				foreach (var inc in include)
				{
					Query = Query.Include(inc);
				}

            }
			return Query.ToList();
        }

		public List<T> GetAllByFilter(Func<T, bool> predicate)
		{
			return _context.Set<T>().Where(predicate).ToList();
		}

		public async Task UpdateAsync(T Work)
		{
			_context.Set<T>().Update(Work);
			await _context.SaveChangesAsync();
		}
		public async Task Delete(T entity)
		{
			await UpdateAsync(entity);
			_context.SaveChanges();
		}

        public async Task<T> GetById(int Id)
        {
			return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == Id);
        }

       
      
    }
}
