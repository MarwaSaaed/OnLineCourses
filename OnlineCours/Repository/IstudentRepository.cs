using OCTW.Server.Repository;
using OnlineCours.DTO;
using OnlineCours.Models;
using System.Linq.Expressions;

namespace OnlineCours.Repository
{
    public interface IstudentRepository : IPersonRepository<Student> 
    {

     Task<StudentDTO> GetStudentsubject(string studentId,string include);

    }
}
