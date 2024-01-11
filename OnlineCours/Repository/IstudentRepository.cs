using OCTW.Server.Repository;
using OnlineCours.DTO;
using OnlineCours.Models;

namespace OnlineCours.Repository
{
    public interface IstudentRepository :IPersonRepository<Student> 
    {
        Task<StudentDTO> GetStudentsubject(string studentId, string include);
    }
}
