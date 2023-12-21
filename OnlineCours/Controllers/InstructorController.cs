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

        [HttpGet("GetInstructorById/{id}")]
        public async Task<ActionResult<InstructorDTO>> GetInstructorById(string id)
        {
            var instructor = await _instructorRepository.GetByFilterAsync(r=>r.applicationUserID == id , "applicationUser");
            if (instructor == null)
            {
                return NotFound();
            }
            InstructorDTO instructorDTO = new InstructorDTO();
            instructorDTO.status = instructor.status;
            instructorDTO.Name = instructor.applicationUser.Name;

            return Ok(instructorDTO);
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
            return Ok(instructors);
        }
    }

}
