using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCours.DTO;
using OnlineCours.Models;
using OnlineCours.Repository;

namespace OnlineCours.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniveristyRequestController : ControllerBase
    {
        private readonly IUniveristyRequestRepositry univeristyRequestRepositry;

        public UniveristyRequestController(IUniveristyRequestRepositry univeristyRequestRepositry)
        {
            this.univeristyRequestRepositry = univeristyRequestRepositry;
        }
        [HttpGet("GetUniveristyStudentRequest")]

        public async Task<ActionResult<List<UniveristyStudentRequestDTO>>> GetUniveristyRequest()
        {
            try
            {
                var request=await univeristyRequestRepositry.GetUniveristyRequest();
                
                return request;
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal Server Error");

            }
        }


        [HttpGet("GetAllUniveristyRequest")]
            public ActionResult<List<UniveristyRequestDTO>> GetAllCoursesRequest()
            {
                try
                {
                    var RequestsOfCourses = univeristyRequestRepositry.GetAllByFilter(x => x.Status == StatusOfStudent.Pendding)
                        .ToList();
                    List<UniveristyRequestDTO> RequestDTOs = new List<UniveristyRequestDTO>();
                    foreach (var item in RequestsOfCourses)
                    {
                    RequestDTOs.Add(new UniveristyRequestDTO
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Description = item.Description,
                            StudentID=item.StudentID,
                            File = item.File,
                        });
                    }
                    return RequestDTOs;
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal Server Error");
                }
            }


            [HttpPost("AddUniveristyRequest")]
            public async Task<IActionResult> AddRequest(UniveristyRequestDTO RequestDTO)
            {
                if (ModelState.IsValid)
                {
                    UniveristyRequest Request = new UniveristyRequest
                    {
                        Name = RequestDTO.Name,
                        StudentID = RequestDTO.StudentID,
                        Description = RequestDTO.Description,
                        File = RequestDTO.File,
                    };
                    await univeristyRequestRepositry.CreateAsync(Request);
                    return Ok("Created");
                }
                return BadRequest(ModelState);
            }

            [HttpPut("AcceptUniveristyRequest{id}")]
            public async Task<IActionResult> AcceptRequest(int id)
            {
                var request = await univeristyRequestRepositry.GetById(id);
                if (request != null)
                {
                    request.Status = StatusOfStudent.Accepted;

                    await univeristyRequestRepositry.UpdateAsync(request);
                    return Ok("Updated");
                }
                return BadRequest("Not Found");
            }
            [HttpPut("RejectedUniveristyRequest{id}")]
            public async Task<IActionResult> RejectedRequest(int id)
            {
                var request = await univeristyRequestRepositry.GetById(id);
                if (request != null)
                {
                    request.Status = StatusOfStudent.Rejected;

                    await univeristyRequestRepositry.UpdateAsync(request);
                    return Ok("Updated");
                }
                return BadRequest("Not Found");
            }

        }

    
}
