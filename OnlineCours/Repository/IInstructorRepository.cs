using OCTW.Server.Repository;
using OnlineCours.DTO;
using OnlineCours.Models;
using System.Linq.Expressions;

namespace OnlineCours.Repository
{
    public interface IInstructorRepository : IPersonRepository<Instructor>
    {
        // Get All Request to Specific Instructor by InstructorID


        // CRUD Bridge
        //Task<List<InstructorDTO>> GetAllAsync();
        //Task<List<InstructorDTO>> GetByDay(int DayOfWeek);
        //Task<InstructorDTO> GetById(string Id);


        //Instructor CreateAsync(Instructor entity);
        //Task UpdateAsync(Instructor entity);

        //Task<List<InstructorDTO>> Get(Expression<Func<Instructor, bool>> expression);
        Task<string> Delete(string id);
        bool Exists(string id);
    }

    
}
