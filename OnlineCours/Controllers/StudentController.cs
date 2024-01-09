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
        public readonly IRequestRepository _requestReopsitory;
        public readonly IRepository<CustomAppointment> _customAppointment;
        public readonly IstudentRepository _studentrepository;

        public StudentController
            (
                IRequestRepository RequestRepository,
                IAppointmentRepositroy AppointmentRepository,
                IInstructorSubjectBridgeRepository InstructorSubjectBridgeRepository,
                IRequestAppointmentRepository RequestAppointmentRepository,
                ISubjectRepository SubjectRepository,
                IRepository<CustomAppointment> CustomAppointment,
                IRequestRepository requestReopsitory,
              IstudentRepository studentrepository
            ) 
        {
            _RequestRepository = RequestRepository;
            _AppointmentRepository = AppointmentRepository;
            _InstructorSubjectBridgeRepository = InstructorSubjectBridgeRepository;
            _RequestAppointmentRepository = RequestAppointmentRepository;
            _SubjectRepository = SubjectRepository;
            _customAppointment = CustomAppointment;
            _requestReopsitory = requestReopsitory;
            _studentrepository= studentrepository;
        }

        [HttpPost("StudentRequestToTakeSubject")]
        public async Task<IActionResult> RequestSubject(StudentRequestToTakeSubject StudentRequestToTakeSubject)
        {
            InstructorSubjectBridge InstructorSubjectBridge = _InstructorSubjectBridgeRepository.
                GetAllByFilter(s => s.SubjectID == StudentRequestToTakeSubject.SubjectId
                && s.InstructorID == StudentRequestToTakeSubject.InstructorId)
                .FirstOrDefault();


            List<Appointment> Appointments = new List<Appointment>();
            foreach (var Appoint in StudentRequestToTakeSubject.Appoinstments)
            {
                if (Enum.TryParse(typeof(Day), Appoint.DayOfWeek, out object dayEnumValue))
                {
                    Day day = (Day)dayEnumValue;

                    Appointment Appointment = _AppointmentRepository.GetAllByFilter
                    (
                        a => a.InstructorSubjectBridgeID == InstructorSubjectBridge.Id
                        && a.DayOfWeek == day
                        && a.LectureDate == Appoint.LectureDate
                    ).FirstOrDefault();

                    Appointments.Add(Appointment);
                }
            }

            Models.Request Request = new Request
            {
                Grade = StudentRequestToTakeSubject.Grade,
                StudentID = StudentRequestToTakeSubject.StudentId,
                NumberOfHouers = StudentRequestToTakeSubject.NumberOfHouers,
            };

            await _RequestRepository.CreateAsync(Request);
            foreach (var Appointment in Appointments)
            {
                CustomAppointment customAppointment = new CustomAppointment
                {
                    DayOfWeek = Appointment.DayOfWeek,
                    InstructorSubjectBridgeID = Appointment.InstructorSubjectBridgeID,
                    InstructorSubjectBridge = Appointment.InstructorSubjectBridge,
                    LectureDate = Appointment.LectureDate,
                    Status = Appointment.Status,
                    IsDeleted = Appointment.IsDeleted,
                };
                await _customAppointment.CreateAsync(customAppointment);

                RequestAppointment RequestAppointment = new RequestAppointment
                {
                    CustomAppointmentID = customAppointment.Id,
                    RequestID = Request.Id,
                };
                await _RequestAppointmentRepository.CreateAsync(RequestAppointment);
            }
            return Ok(new Result { Message = "Created" });
        }




        [HttpGet("GetAllAcceptedRequest")]
        public async Task<ActionResult<List<RequestAppointmentDTO>>> GetAllAcceptedRequest()
        {
            var instructors = await _requestReopsitory.GetAllAcceptedRequest();
            return Ok(instructors);
        }

        [HttpGet("GetAllPendingRequest")]
        public async Task<ActionResult<List<RequestAppointmentDTO>>> GetAllPendingRequest()
        {
            var instructors = await _requestReopsitory.GetAllPenddingRequest();
            return Ok(instructors);
        }
        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetStudentswithIdandsubject(string studentId)
        {
            var studentDto = await _studentrepository.GetStudentsubject(studentId, "ApplicationUser");

            if (studentDto == null)
            {

                return NotFound();
            }

            return Ok(studentDto);
        }


        [HttpPut("UpdateStudent/{id}")]
        public async Task<IActionResult> UpdateStudent(string id, StudentDTO student)
        {
            var OldStudent = await _studentrepository.GetByFilterAsync(s => s.ApplicationUserID == id, "ApplicationUser");

            if (OldStudent == null)
            {
                return NotFound();
            }
            OldStudent.ApplicationUser.Name = student.Name;
            OldStudent.ApplicationUser.PhoneNumber = student.Phone;
            OldStudent.ApplicationUser.Email = student.Email;
            await _studentrepository.UpdateAsync(OldStudent);
            return Ok("updated");
        }

            [HttpGet("subjects/{studentId}")]
            public async Task<ActionResult<List<StudentLibraryDTO>>> GetSubjectsByStudent(string studentId)
            {
                try
                {
                    var result = await _SubjectRepository.GetSubjectsByStudent(studentId);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                
                    return StatusCode(500, "Internal server error");
                }
            }
        }
 }


