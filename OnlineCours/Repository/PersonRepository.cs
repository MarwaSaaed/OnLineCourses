using Microsoft.EntityFrameworkCore;
using OnlineCours.Models;
using System.Linq.Expressions;

namespace OCTW.Server.Repository
{
    public class PersonRepository<T> : IPersonRepository<T> where T : class
    {
        private readonly Context _context;
        public PersonRepository(Context context)
        {
            _context = context;

        }
        public async Task CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

      

        public  async Task<IEnumerable<T>> GetAllAsync(string Include)
        {
            return await _context.Set<T>().Include(Include).ToListAsync();
        }

        public  IEnumerable<T> GetByFilterAsync(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

       

        // Hande By ID with in next function with FOD

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }


        public async Task<T> GetByPredicateAsync(Expression<Func<T, bool>> predicate, string includeProperties = "")

        {
            IQueryable<T> query = _context.Set<T>();

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.FirstOrDefaultAsync(predicate);
        }

        
       
    }

}

