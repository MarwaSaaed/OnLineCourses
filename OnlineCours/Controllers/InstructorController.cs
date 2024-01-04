using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCours.DTO;
using OnlineCours.Models;
using OnlineCours.Repository;

namespace OnlineCours.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorController(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
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


        //[HttpPut("UpdateInstructor/{id}")]
        //public async Task<IActionResult> UpdateInstructor(string id, Instructor instructor)
        //{
        //    if (id != instructor.applicationUserID)
        //    {
        //        return BadRequest();
        //    }

        //    try
        //    {
        //        await _instructorRepository.UpdateAsync(instructor);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!_instructorRepository.Exists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}


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
            return Ok(instructors);
        }


        [HttpGet("GetBySubject/{SubjectId}")]
        public async Task<IActionResult> GetInstructorBySubject(int SubjectId)
        {
            var Result = await _instructorRepository.GetBySubject(SubjectId);

            return Ok(Result);
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

        //[HttpGet("GetInstructorById/{id}")]
        //public async Task<ActionResult<InstructorDTO>> GetInstructorById(string id)
        //{
        //    var instructor = await _instructorRepository.GetByFilterAsync(r => r.applicationUserID == id, "applicationUser");
        //    if (instructor == null)
        //    {
        //        return NotFound();
        //    }

        //    InstructorDTO instructorDTO = new InstructorDTO
        //    {
        //        Id = instructor.applicationUserID,
        //        Name = instructor.applicationUser.Name,
        //        Email = instructor.applicationUser.Email,
        //        Phone = instructor.applicationUser.PhoneNumber,
        //        status = instructor.status,
               

        //    };

        //    return Ok(instructorDTO);
        //}

        //[HttpPut("AcceptInstructor/{Id}")]
        //public async Task<IActionResult> GetInstructorBySubject(string Id)
        //{
        //    var instrucor =await _instructorRepository.GetById(Id);
        //    if(instrucor!=null)
        //    {
        //         instrucor.status = StatusOfInstructor.Accepted;
        //        I
        //         await _instructorRepository.UpdateAsync(instrucor);

        //    }
        //    return Ok(Result);
        //}


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
    }

}
