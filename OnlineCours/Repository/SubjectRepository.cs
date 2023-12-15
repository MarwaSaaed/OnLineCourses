using Microsoft.EntityFrameworkCore;
using OCTW.Server.Repository;
using OnlineCours.Models;

namespace OnlineCours.Repository
{
    public class SubjectRepository : Repository<Subject> ,ISubjectRepository
    {
        public readonly Context _Context;
        public SubjectRepository(Context context) : base(context)
        {
            _Context = context;
        }

        public async Task<List<Subject>> GetSubjectsByStudent(string StudentId)
        {
            var query = await _Context.RequestAppointments
                .Include(r => r.Request)
                .Where(r => r.Request.StudentID == StudentId)
                .Include(r => r.Appointment)
                .ThenInclude(r => r.InstructorSubjectBridge)
                .ThenInclude(r => r.Subject).ToListAsync();
            return query.Select(s => s.Appointment.InstructorSubjectBridge.Subject).ToList();

        }
    }
}
