using OCTW.Server.Repository;
using OnlineCours.DTO;
using OnlineCours.Models;

namespace OnlineCours.Repository
{
    public interface IstudentRepository :IPersonRepository<Student> 
    {
        Task<StudentDTO> GetStudentsubject(string studentId, string include);
        Task<List<TutorialResponseDto>> GetTutorial(string studentId);
        Task<List<TutorialResponse2Dto>> GetTutorial2(string studentId);
    }
   

}
