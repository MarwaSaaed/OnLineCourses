using OCTW.Server.Repository;
using OnlineCours.DTO;
using OnlineCours.Models;
using System.Linq.Expressions;

namespace OnlineCours.Repository
{
    public interface IInstructorRepository
    {
        Task<InstructorDTO> GetById(string Id);
        Task<List<InstructorDTO>> GetByDay(int DayOfWeek);
        Task<List<InstructorDTO>> GetAllAsync();
        Instructor CreateAsync(Instructor entity);
        Task UpdateAsync(Instructor entity);
        Task<string> Delete(string id);
        Task<List<InstructorDTO>> Get(Expression<Func<Instructor, bool>> expression);
        bool Exists(string id);
    }

    
}
