using Microsoft.EntityFrameworkCore;
using OCTW.Server.Repository;
using OnlineCours.DTO;
using OnlineCours.Models;

namespace OnlineCours.Repository
{
    public class studentRepository : PersonRepository<Student>, IstudentRepository
    {
        public readonly Context Context;
        public studentRepository(Context context) : base(context)
        {
            Context = context;
        }

        public async Task<StudentDTO> GetStudentsubject(string studentId,string include)
        {
            var query = await Context.RequestAppointments
                .Include(r => r.Request)
                .ThenInclude(r=>r.Student).ThenInclude(r=>r.ApplicationUser)
                .Where(r => r.Request.StudentID == studentId)
                .Include(r => r.CustomAppointment)
                .ThenInclude(r => r.InstructorSubjectBridge)
                .ThenInclude(r => r.Subject)
                .FirstOrDefaultAsync();

            if (query == null)
            {
                
                return null;
            }

            return new StudentDTO
            {
                Id = query.Request.Student.ApplicationUser.Id,
                Name = query.Request.Student.ApplicationUser.Name, 
                Email = query.Request.Student.ApplicationUser.Email, 
                Phone = query.Request.Student.ApplicationUser.PhoneNumber, 
                Numberofhours = (int)query.Request.NumberOfHouers,
                Subjects = new List<string> { query.CustomAppointment.InstructorSubjectBridge.Subject.Name }
                
            };
        }


    }
}
