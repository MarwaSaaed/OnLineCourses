using OCTW.Server.Repository;
using OnlineCours.Models;

namespace OnlineCours.Repository
{
    public interface IRequestAppointmentRepository:IRepository<RequestAppointment>
    {
        public Task<List<RequestAppointment>> GetAllRequest();

    }
}
