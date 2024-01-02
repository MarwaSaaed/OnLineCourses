using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCours.DTO;
using OnlineCours.Models;
using OnlineCours.Repository;

namespace OnlineCours.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherRequestsController : ControllerBase
    {
        private readonly IOtherRequestRepositry otherRequestRepositry;

        public OtherRequestsController(IOtherRequestRepositry otherRequestRepositry)
        {
            this.otherRequestRepositry = otherRequestRepositry;
        }
        [HttpGet("GetAllConsultingRequest")]
        public ActionResult<List<OtherRequestDTO>> GetAllConsultingRequest()
        {
            try
            {
                var Requests = otherRequestRepositry.GetAllByFilter(x => x.Status == StatusOfStudent.Pendding)
                    .ToList();
                List<OtherRequestDTO> RequestDTOs = new List<OtherRequestDTO>();
                foreach (var item in Requests)
                {
                    RequestDTOs.Add(new OtherRequestDTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        PhoneNumber = item.PhoneNumber,
                        File = item.File,
                        Email = item.Email,
                        ConsultingHoures=item.ConsultingHoures,
                    });
                }
                return RequestDTOs;
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }



        [HttpPost("AddRequest")]
        public async Task<IActionResult> AddRequest(OtherRequestDTO otherRequestDTO)
        {
           if(ModelState.IsValid)
            {
                OtherRequest otherRequest = new OtherRequest
                {
                    Name = otherRequestDTO.Name,
                    Email = otherRequestDTO.Email,
                    PhoneNumber = otherRequestDTO.PhoneNumber,
                    Description = otherRequestDTO.Description,
                    ConsultingHoures = otherRequestDTO.ConsultingHoures,
                    File = otherRequestDTO.File,
                };
                await otherRequestRepositry.CreateAsync(otherRequest);
                return Ok("Created");
            }
            return BadRequest(ModelState);
        }

        [HttpPut("AcceptRequest{id}")]
        public async Task<IActionResult> AcceptRequest(int id)
        {
            var request = await otherRequestRepositry.GetById(id);
           if(request!=null)
            {
                request.Status = StatusOfStudent.Accepted;

                await otherRequestRepositry.UpdateAsync(request);
                return Ok("Updated");
            }
            return BadRequest("Not Found");

        }
        [HttpPut("RejectedRequest{id}")]
        public async Task<IActionResult> RejectedRequest(int id)
        {
            var request = await otherRequestRepositry.GetById(id);
           if(request!=null )
            {
                request.Status = StatusOfStudent.Rejected;

                await otherRequestRepositry.UpdateAsync(request);
                return Ok("Updated");
            }
            return BadRequest("Not Found");

        }

    }
}
