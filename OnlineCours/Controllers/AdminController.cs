﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OCTW.Server.Repository;
using OnlineCours.DTO;
using OnlineCours.Models;
using OnlineCours.Repository;

namespace OnlineCours.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ISubjectRepository _CourseRepository;
        private readonly IRequestAppointmentRepository _RequestAppointmentRepository;
        private readonly IRequestRepository _Request;
        private readonly IPersonRepository<Instructor> _InstructorRepository;
        public AdminController(IPersonRepository<Instructor> InstructorRepository, 
            IRequestRepository Request, ISubjectRepository CourseRepository,
            IRequestAppointmentRepository RequestAppointmentRepository)
        {
            _CourseRepository = CourseRepository;
            _RequestAppointmentRepository = RequestAppointmentRepository;
            _Request = Request;
            _InstructorRepository = InstructorRepository;
        }


        [HttpPost("AddSubject")]
        public async Task<IActionResult> AddSubject(AddSubjectRequest AddSubjectRequest)
        {
            Subject Subject = new Subject
            {
                Grade = AddSubjectRequest.Grade,
                Name = AddSubjectRequest.Name,
            };
            await _CourseRepository.CreateAsync(Subject);
            return Ok("Created");
        }

        [HttpGet("GetAllStudentRequests")]
        public async Task<IActionResult> GetAllStudentRequest()
        {

            List<RequestAppointment> RequestAppointment =
                await _RequestAppointmentRepository.GetAllRequest();
            return Ok(RequestAppointment);
        }

        [HttpPut("AcceptStudentRequest/{RequestId}")]
        public async Task<IActionResult> AcceptStudentRequest(int RequestId)
        {
            var allRequest = await _Request.GetAllAsync();
            var Request = allRequest.FirstOrDefault(rqu => rqu.Id == RequestId);
            if (Request != null)
            {
                Request.status = StatusOfStudent.Accepted;
                await _Request.UpdateAsync(Request);
                return Ok(Request);
            }
            return NotFound("RequestNotFound");

        }


        [HttpPut("RejectStudentRequest/{RequestId}")]
        public async Task<IActionResult> RejectStudentRequest(int RequestId)
        {
            var Request = await _Request.GetById(RequestId);
            if (Request != null)
            {

                Request.status = StatusOfStudent.Rejected;
                await _Request.UpdateAsync(Request);
                return Ok(Request);
            }
            return BadRequest();

        }


        [HttpPut("AcceptInstructorRequest/{InstructorId}")]
        public async Task<IActionResult> AcceptInstructor(string InstructorId)
        {
            var Instructors =
                await _InstructorRepository.GetAllAsync();
            Instructor Instructor = Instructors.FirstOrDefault(i => i.applicationUserID == InstructorId);
            if (Instructor != null)
            {

                Instructor.status = StatusOfInstructor.Accepted;
                await _InstructorRepository.UpdateAsync(Instructor);
                return Ok(Instructor);
            }
            return BadRequest();
        }


        [HttpPut("RejectInstructorRequest/{InstructorId}")]
        public async Task<IActionResult> RejectInstructor(string InstructorId)
        {
            var Instructors =
                await _InstructorRepository.GetAllAsync();
            Instructor Instructor = Instructors.FirstOrDefault(i => i.applicationUserID == InstructorId);
            if (Instructor != null)
            {

                Instructor.status = StatusOfInstructor.Rejected;
                await _InstructorRepository.UpdateAsync(Instructor);
                return Ok(Instructor);
            }
            return BadRequest();
        }


        [HttpGet("GetAllSubjects")]
        public async Task<IActionResult> GetAllSubjects()
        {

            var subjects = await _CourseRepository.GetAllAsync();

            List<AddSubjectRequest> subjectsDTO = new List<AddSubjectRequest>();
            foreach (var subject in subjects)
            {
                subjectsDTO.Add(new AddSubjectRequest
                {
                    Id = subject.Id,
                    Name = subject.Name,
                    Grade = subject.Grade
                });


            }

            return Ok(subjectsDTO);
        }


        [HttpPut("UpdateSubject/{Id}")]
        public async Task<IActionResult> UpdateSubject(int Id, AddSubjectRequest Subject)
        {
            if (Id == Subject.Id)
            {
                if (ModelState.IsValid)
                {
                    var subject = await _CourseRepository.GetById(Id);
                    if (subject != null)
                    {

                        subject.Name = Subject.Name;
                        subject.Grade = Subject.Grade;
                        await _CourseRepository.UpdateAsync(subject);
                        return Ok("Updated");
                    }
                    return BadRequest("Not Found");

                }
                return BadRequest(ModelState);
            }

            return NotFound("RequestNotFound");

        }


        [HttpGet("GetSubject/{Id}")]
        public async Task<IActionResult> GetSubject(int Id)
        {
            if (Id != 0)
            {
                var subject = await _CourseRepository.GetById(Id);
                if (subject != null)
                {
                    AddSubjectRequest subjectDTo = new AddSubjectRequest();
                    subjectDTo.Id = subject.Id;
                    subjectDTo.Name = subject.Name;
                    subjectDTo.Grade = subject.Grade;
                    return Ok(subjectDTo);
                }
                return BadRequest("Not Found");
            }
            return BadRequest("NotFound");

        }


        [HttpDelete("DeleteSubject/{Id}")]
        public async Task<IActionResult> DeleteSubject(int Id)
        {
            if (Id != 0)
            {
                var subject = await _CourseRepository.GetById(Id);
                if (subject != null)
                {
                    subject.IsDeleted = true;
                   await _CourseRepository.Delete(subject);
                    return Ok("Deleted");
                }
                return BadRequest("Not Found");
            }
            return BadRequest("NotFound");

        }

    }
}
