using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCours.DTO;
using OnlineCours.Models;
using OnlineCours.Repository;

namespace OnlineCours.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseRequestController : ControllerBase
    {
        private readonly ICourseRequesRepositry courseRequesRepositry;

        public CourseRequestController(ICourseRequesRepositry courseRequesRepositry)
        {
            this.courseRequesRepositry = courseRequesRepositry;
        }
        [HttpGet("GetAllCoursesRequest")]
        public ActionResult<List<CourseRequestDTO>> GetAllCoursesRequest()
        {
            try
            {
                var RequestsOfCourses = courseRequesRepositry.GetAllByFilter(x => x.Status == StatusOfStudent.Pendding)
                    .ToList();
                List<CourseRequestDTO> courseRequestDTOs = new List<CourseRequestDTO>();
                foreach (var item in RequestsOfCourses)
                {
                    courseRequestDTOs.Add(new CourseRequestDTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        PhoneNumber = item.PhoneNumber,
                        File = item.File,
                        Email = item.Email
                    });
                }
                return courseRequestDTOs;
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpPost("AddCourseRequest")]
        public async Task<IActionResult> AddRequest(CourseRequestDTO courseRequestDTO)
        {
           if(ModelState.IsValid)
            {
                CourseRequest Request = new CourseRequest
                {
                    Name = courseRequestDTO.Name,
                    Email = courseRequestDTO.Email,
                    PhoneNumber = courseRequestDTO.PhoneNumber,
                    Description = courseRequestDTO.Description,
                    File = courseRequestDTO.File,
                };
                await courseRequesRepositry.CreateAsync(Request);
                return Ok("Created");
            }
            return BadRequest(ModelState);
        }

        [HttpPut("AcceptCourseRequest{id}")]
        public async Task<IActionResult> AcceptRequest(int id)
        {
            var request = await courseRequesRepositry.GetById(id);
            if(request!=null)
            {
                request.Status = StatusOfStudent.Accepted;

                await courseRequesRepositry.UpdateAsync(request);
                return Ok("Updated");
            }
            return BadRequest("Not Found");
        }
        [HttpPut("RejectedCourseRequest{id}")]
        public async Task<IActionResult> RejectedRequest(int id)
        {
            var request = await courseRequesRepositry.GetById(id);
            if (request != null)
            { 
              request.Status = StatusOfStudent.Rejected;

              await courseRequesRepositry.UpdateAsync(request);
              return Ok("Updated");
        }
        return BadRequest("Not Found");
    }

}
}
