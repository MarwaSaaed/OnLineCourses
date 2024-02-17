using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OCTW.Server.Repository;
using OnlineCours.DTO;
using OnlineCours.Models;
using OnlineCours.Repository;
using System.Reflection.Metadata.Ecma335;

namespace OnlineCours.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IRepository<CustomAppointment> _CustomAppointmentRepository;
        private readonly IRepository<Appointment> _AppointmentRepository;
        private readonly IRepository<Tutorial> _TutorialRepository;
        private readonly IRepository<SubjectTutorial> _SubjectTutorialRepository;
        private readonly IInstructorSubjectBridgeRepository _InstructorSubjectBridgeRepository;


        public InstructorController(IRepository<SubjectTutorial> SubjectTutorialRepository,
            IInstructorSubjectBridgeRepository InstructorSubjectBridgeRepository, 
            IRepository<Tutorial> tutorialRepository, IInstructorRepository instructorRepository, 
            IRepository<CustomAppointment> CustomAppointmentRepository,
            IRepository<Appointment> AppointmentRepository)
        {
            _instructorRepository = instructorRepository;
            _CustomAppointmentRepository = CustomAppointmentRepository;
            _TutorialRepository = tutorialRepository;
            _InstructorSubjectBridgeRepository = InstructorSubjectBridgeRepository;
            _SubjectTutorialRepository = SubjectTutorialRepository;
            _AppointmentRepository = AppointmentRepository;
        }

        [HttpGet("GetAllInstructors")]
        public async Task<ActionResult<List<InstructorDTO>>> GetAllInstructors()
        {
            var instructors = await _instructorRepository.GetAllAsync();
            return Ok(instructors);
        }
        [HttpGet("GetAllAcceptedInstructors")]
        public async Task<ActionResult<List<InstructorDTO>>> GetAllAcceptedInstructors()
        {
            var instructors = await _instructorRepository.GetAllAcceptedInstructors();
            return Ok(instructors);
        }

        [HttpGet("GetAllPendingInstructors")]
        public async Task<ActionResult<List<InstructorDTO>>> GetAllPendingInstructors()
        {
            var instructors = await _instructorRepository.GetAllPendingInstructoresAsync();
            return Ok(instructors);
        }

        [HttpGet("GetInstructorById/{id}")]
        public async Task<ActionResult<InstructorDTO>> GetInstructorById(string id)
        {
            var instructor = await _instructorRepository.GetById(id);
            if (instructor == null)
            {
                return NotFound();
            }


            return Ok(instructor);
        }


        [HttpPut("UpdateInstructor/{id}")]
        public async Task<IActionResult> UpdateInstructor(string id, Instructor instructor)
        {
            if (id != instructor.applicationUserID)
            {
                return BadRequest();
            }

            try
            {
                await _instructorRepository.UpdateAsync(instructor);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_instructorRepository.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpDelete("DeleteInstructor/{id}")]
        public async Task<IActionResult> DeleteInstructor(string id)
        {
            var result = await _instructorRepository.Delete(id);
            return Ok(result);
        }


        //[HttpGet("day/{dayOfWeek}")]
        //public async Task<ActionResult<List<InstructorDTO>>> GetInstructorsByDay(int dayOfWeek)
        //{
        //    var instructors = await _instructorRepository.GetByDay(dayOfWeek);
        //    return Ok(instructors);
        //}

        [HttpGet("GetRequestForInstructor/{Id}")]
        public async Task<IActionResult> GetRequestForInstructor(string Id)
        {
            var Result = await _instructorRepository.GetAllRequestToByInstructorId(Id);

            return Ok(Result);
        }

        [HttpPost("AddInstructorSubject")]
        public async Task<ActionResult> AddInstructorSubject(InstructorSubjectDTO instructorSubjectDTO)
        {
            var instructors = await _instructorRepository.AddInstructorSubject(instructorSubjectDTO);
            return Ok();
        }


        [HttpGet("GetBySubject/{SubjectId}")]
        public async Task<IActionResult> GetInstructorBySubject(int SubjectId)
        {
            var Result = await _instructorRepository.GetBySubject(SubjectId);

            return Ok(Result);
        }

        [HttpPut("EditAppointment/{id}")]
        public async Task<IActionResult> EditAppointmentForUser(int id, EditAppointmentModel EditAppointmentModel)
        {
            var appointmetn = await _CustomAppointmentRepository.GetById(id);
            if (appointmetn != null)
            {
                appointmetn.LectureDate = EditAppointmentModel.LectureDate;
                Enum.TryParse(typeof(Day), EditAppointmentModel.DayOfWeek, out object dayEnumValue);
                Day day = (Day)dayEnumValue;
                appointmetn.DayOfWeek = day;
                await _CustomAppointmentRepository.UpdateAsync(appointmetn);
                return Ok(appointmetn);

            }
            return Conflict("The appointment not found");
        }

        [HttpPut("EditInstructorAppointment/{id}")]
        public async Task<IActionResult> EditInstructorAppointment(int id, EditAppointmentModel EditAppointmentModel)
        {
            var appointmetn = await _AppointmentRepository.GetById(id);
            if (appointmetn != null)
            {
                appointmetn.LectureDate = EditAppointmentModel.LectureDate;
                Enum.TryParse(typeof(Day), EditAppointmentModel.DayOfWeek, out object dayEnumValue);
                Day day = (Day)dayEnumValue;
                appointmetn.DayOfWeek = day;
                await _AppointmentRepository.UpdateAsync(appointmetn);
                return Ok(appointmetn);

            }
            return Conflict("The appointment not found");
        }


        [HttpPost("UploadTutorial")]
        public async Task<IActionResult> UploadTutorialOfSubjcet(UploadTutorialModel uploadTutorialModel)
        {
            var InsSubject = _InstructorSubjectBridgeRepository.GetAllByFilter(x => x.InstructorID == uploadTutorialModel.InstructorId && x.SubjectID == uploadTutorialModel.SubjcetId)
                .FirstOrDefault();
            if (InsSubject != null)
            {

                Tutorial Tutorial = new Tutorial
                {
                    InstructorSubjectId = InsSubject.Id,
                    Name = uploadTutorialModel.TutorialName,
                    StudentId = uploadTutorialModel.StudentId,
                };
                await _TutorialRepository.CreateAsync(Tutorial);

                foreach(var item in uploadTutorialModel.Tutorial)
                {
                    SubjectTutorial subjectTutorial = new SubjectTutorial
                    {
                        subjectTutorial = item.subjectTutorial,
                        TutorialType = item.TutorialType,
                        TutorialId = Tutorial.Id,
                    };
                    await _SubjectTutorialRepository.CreateAsync(subjectTutorial);
                }
                return Ok(Tutorial);
            }
            else
            {
                return Conflict();
            }

        }
        [HttpPut("UpdateInstructorProfile/{id}")]
        public async Task<IActionResult> UpdateInstructor(string id, UpdateInstructorDTO instructor)
        {
            var oldInstructor = await _instructorRepository.GetByFilterAsync(s => s.applicationUserID == id, "applicationUser");

            if (oldInstructor == null)
            {
                return NotFound();
            }
            oldInstructor.applicationUser.Name = instructor.Name;
            oldInstructor.applicationUser.PhoneNumber = instructor.phone;
            oldInstructor.applicationUser.Email = instructor.Email;
            await _instructorRepository.UpdateAsync(oldInstructor);
            return Ok("updated");
        }

        [HttpGet("GetInstructorWithSubject/{id}")]
        public async Task<ActionResult<InstructorDTO>> GetInstructorWithsubject(string id)
        {

            var instructorwithsubject = await _instructorRepository.GetInstructorWithSubject(id);
            if (instructorwithsubject == null)
            {
                return NotFound();
            }
            return instructorwithsubject;

        }


        [HttpGet("GetInstructorSubjectandAppointment/{id}")]
        public async Task<ActionResult<InstructorSubjectsAndAppointmentDTO>> GetInstructorSubjectandAppointment(string id)
        {

            var instructorwithsubject = await _instructorRepository.GetInstructorSubjectandAppointment(id);
            if (instructorwithsubject == null)
            {
                return NotFound();
            }
            return instructorwithsubject;

        }
    }
}