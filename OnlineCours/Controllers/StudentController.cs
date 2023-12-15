using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using OCTW.Server.Repository;
using OnlineCours.DTO;
using OnlineCours.Models;
using OnlineCours.Repository;
using System.Linq.Expressions;

namespace OnlineCours.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public readonly IRequestRepository _RequestRepository;
        public readonly IAppointmentRepositroy _AppointmentRepository;
        public readonly IInstructorSubjectBridgeRepository _InstructorSubjectBridgeRepository;
        public readonly IRequestAppointmentRepository _RequestAppointmentRepository;
        public readonly ISubjectRepository _SubjectRepository;
        public StudentController
            (
                IRequestRepository RequestRepository,
                IAppointmentRepositroy AppointmentRepository,
                IInstructorSubjectBridgeRepository InstructorSubjectBridgeRepository,
                IRequestAppointmentRepository RequestAppointmentRepository,
                ISubjectRepository SubjectRepository
            ) 
        {
            _RequestRepository = RequestRepository;
            _AppointmentRepository = AppointmentRepository;
            _InstructorSubjectBridgeRepository = InstructorSubjectBridgeRepository;
            _RequestAppointmentRepository = RequestAppointmentRepository;
            _SubjectRepository = SubjectRepository;
        }
        [HttpPost("StudentRequestToTakeSubject")]
        public  async Task<IActionResult> RequestSubject(StudentRequestToTakeSubject StudentRequestToTakeSubject)
        {
            InstructorSubjectBridge InstructorSubjectBridge = _InstructorSubjectBridgeRepository.
                GetAllByFilter(s=>s.SubjectID == StudentRequestToTakeSubject.SubjectId
                && s.InstructorID == StudentRequestToTakeSubject.InstructorId)
                .FirstOrDefault();



            List<Appointment> Appointments = new List<Appointment>();
            foreach (var Appoint in StudentRequestToTakeSubject.Appoinstments)
            {
                Appointment Appointment = _AppointmentRepository.GetAllByFilter
                  (
                      a => a.InstructorSubjectBridgeID == InstructorSubjectBridge.Id
                      && a.DayOfWeek == Appoint.DayOfWeek
                      && a.LectureDate == Appoint.LectureDate
                  ).FirstOrDefault();
                Appointments.Add(Appointment);
            }



            Models.Request Request = new Request
            {
                Grade = StudentRequestToTakeSubject.Grade,
                StudentID = StudentRequestToTakeSubject.StudentId,
            };


           await _RequestRepository.CreateAsync(Request);
            foreach(var Appointment in Appointments) 
            {

                RequestAppointment RequestAppointment = new RequestAppointment
                {
                    AppointmentID = Appointment.Id,
                    RequestID = Request.Id,
                };
                await _RequestAppointmentRepository.CreateAsync(RequestAppointment);
            }


            return Ok(new Result { Message = "Created" });
                
        }
    
        public  async Task <IActionResult> GetStudentSubject(string StudentId)
        {
            List<Subject> Subjects = await _SubjectRepository.GetSubjectsByStudent(StudentId);
            return Ok(Subjects);
        }
    }
}
