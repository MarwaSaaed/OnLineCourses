using OCTW.Server.Repository;
using OnlineCours.DTO;
using OnlineCours.Models;
using System.Linq.Expressions;

namespace OnlineCours.Repository
{
    public interface IInstructorRepository : IPersonRepository<Instructor>
    {
        public Task<List<StudentRequestForInstructor>> GetAllRequestToByInstructorId(string InstructorId);


        // CRUD Bridge
        Task<List<InstructorDTO>> GetAllAsync();
        Task<List<InstructorDTO>> GetByDay(int DayOfWeek);
        Task<List<InstructorDTO>> GetBySubject(int SubjectId);
        Task<InstructorDTO> GetById(string Id);

        Task<List<InstructorDTO>> GetAllAcceptedInstructors();


        Task<List<InstructorDTO>> Get(Expression<Func<Instructor, bool>> expression);
        Task<string> Delete(string id);
        Task<string> AddInstructorSubject(InstructorSubjectDTO instructorSubjectDTO);
        bool Exists(string id);
       Task<List<InstructorDTO>> GetAllPendingInstructoresAsync();

    }
}
