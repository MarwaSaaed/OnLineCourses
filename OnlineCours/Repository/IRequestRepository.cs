using OCTW.Server.Repository;
using OnlineCours.DTO;
using OnlineCours.Models;

namespace OnlineCours.Repository
{
    public interface IRequestRepository : IRepository<Request>
    {
        Task<List<RequestAppointmentDTO>> GetAllAcceptedRequest();
        Task<List<RequestAppointmentDTO>> GetAllPenddingRequest();
    }
}
