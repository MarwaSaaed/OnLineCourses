using Microsoft.EntityFrameworkCore;
using OCTW.Server.Repository;
using OnlineCours.DTO;
using OnlineCours.Models;

namespace OnlineCours.Repository
{
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        public readonly Context _Context;
        public SubjectRepository(Context context) : base(context)
        {
            _Context = context;
        }
        public async Task<List<StudentLibraryDTO>> GetSubjectsByStudent(string StudentId)
        {
            var query = await _Context.RequestAppointments
                .Include(r => r.Request)
                .Where(r => r.Request.StudentID == StudentId)
                .Include(r => r.CustomAppointment)
                .ThenInclude(r => r.InstructorSubjectBridge)
                .ThenInclude(r => r.Subject)
                .Include(r => r.CustomAppointment.InstructorSubjectBridge.Instructor)
                .ThenInclude(i => i.applicationUser) // Assuming ApplicationUser is a property in your Instructor class
                .ToListAsync();

            var result = query
                .GroupBy(s => new { InstructorId = s.CustomAppointment.InstructorSubjectBridge.Instructor.applicationUserID, InstructorName = s.CustomAppointment.InstructorSubjectBridge.Instructor.applicationUser.Name })
                .Select(group => new StudentLibraryDTO
                {
                    InstructorId=group.Key.InstructorId,
                    InstructorName = group.Key.InstructorName,
                    Subjects = group.Select(s => new SubjectDTOLiberary
                    {
                        Id = s.CustomAppointment.InstructorSubjectBridge.Subject.Id,
                        SubjectName = s.CustomAppointment.InstructorSubjectBridge.Subject.Name,
                        NumberOfHours = (int)s.Request.NumberOfHouers, // Fix here: Access Request property on each individual RequestAppointment
                    }).ToList()
                })
                .ToList();

            return result;
        }


    }
}
