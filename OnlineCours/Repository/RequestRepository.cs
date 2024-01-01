using Microsoft.EntityFrameworkCore;
using OCTW.Server.Repository;
using OnlineCours.DTO;
using OnlineCours.Models;

namespace OnlineCours.Repository
{
    public class RequestRepository : Repository<Request>, IRequestRepository
    {
        Context _context { get; set; }
        public RequestRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<List<RequestAppointmentDTO>> GetAllAcceptedRequest()
        {
            List<RequestAppointment> requestAppointments = await _context.RequestAppointments
                                .Include(x => x.Request)
                                .ThenInclude(st=>st.Student)
                                .ThenInclude(v=>v.ApplicationUser)
                                .Include(c=>c.CustomAppointment)
                                .ThenInclude(ins=> ins.InstructorSubjectBridge)
                                .ThenInclude(instr => instr.Instructor)
                                .ThenInclude(iapp=>iapp.applicationUser)
                                .Where(x => x.Request.status == StatusOfStudent.Accepted)
                                .ToListAsync();


            List<RequestAppointmentDTO> requestAppointment = new List<RequestAppointmentDTO>();

            foreach (var request in requestAppointments)
            {
                requestAppointment.Add(new RequestAppointmentDTO
                {
                    Id = request.Id,
                    RequestId = request.Request.Id,
                    StudentName = request.Request.Student.ApplicationUser.Name,
                    StudentEmail = request.Request.Student.ApplicationUser.Email,
                    StudentPhoneNumber = request.Request.Student.ApplicationUser.PhoneNumber,
                    status = request.Request.status,
                    NumberOfHouers = request.Request.NumberOfHouers,
                    Grade = request.Request.Grade,
                    InstructorName = request.CustomAppointment
                                            .InstructorSubjectBridge
                                            .Instructor.applicationUser.Name,
                });
            }

            return requestAppointment;
        }

        public async Task<List<RequestAppointmentDTO>> GetAllPenddingRequest()
        {
            List<RequestAppointment> requestAppointments = await _context.RequestAppointments
                                .Include(x => x.Request)
                                .ThenInclude(st => st.Student)
                                .ThenInclude(v => v.ApplicationUser)
                                .Include(c => c.CustomAppointment)
                                .ThenInclude(ins => ins.InstructorSubjectBridge)
                                .ThenInclude(instr => instr.Instructor)
                                .ThenInclude(iapp => iapp.applicationUser)
                                .Where(x => x.Request.status == StatusOfStudent.Pendding)
                                .ToListAsync();


            List<RequestAppointmentDTO> requestAppointment = new List<RequestAppointmentDTO>();

            foreach (var request in requestAppointments)
            {
                requestAppointment.Add(new RequestAppointmentDTO
                {
                    Id = request.Id,
                    RequestId = request.Request.Id,
                    StudentName = request.Request.Student.ApplicationUser.Name,
                    StudentEmail = request.Request.Student.ApplicationUser.Email,
                    StudentPhoneNumber = request.Request.Student.ApplicationUser.PhoneNumber,
                    status = request.Request.status,
                    NumberOfHouers = request.Request.NumberOfHouers,
                    Grade = request.Request.Grade,
                    InstructorName = request.CustomAppointment
                                            .InstructorSubjectBridge
                                            .Instructor.applicationUser.Name,
                });
            }

            return requestAppointment;
        }
    }
}
