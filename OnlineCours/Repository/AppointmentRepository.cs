using OCTW.Server.Repository;
using OnlineCours.Models;

namespace OnlineCours.Repository
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepositroy
    {
        public AppointmentRepository(Context context) : base(context)
        {
        }
    }
}