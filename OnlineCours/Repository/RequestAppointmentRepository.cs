using Microsoft.EntityFrameworkCore;
using OCTW.Server.Repository;
using OnlineCours.Models;

namespace OnlineCours.Repository
{
    public class RequestAppointmentRepository : Repository<RequestAppointment>, IRequestAppointmentRepository
    {
        private readonly Context _Context;
        public RequestAppointmentRepository(Context context) : base(context)
        {
            _Context = context;
        }
        public async Task<List<RequestAppointment>> GetAllRequest()
        {
            List<RequestAppointment> RequestAppointment = await _Context.RequestAppointments
                .Include(r=>r.Appointment)
                .ThenInclude(r=>r.InstructorSubjectBridge)
                .ThenInclude(r=>r.Instructor)
                .Include(r => r.Appointment)
                .ThenInclude(r => r.InstructorSubjectBridge)
                .ThenInclude(r => r.Subject).ToListAsync();
            return RequestAppointment;
        }
    }
}
