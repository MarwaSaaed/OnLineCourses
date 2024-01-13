using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using OCTW.Server.Repository;
using OnlineCours.DTO;
using OnlineCours.Models;

namespace OnlineCours.Repository
{

    public class studentRepository : PersonRepository<Student>, IstudentRepository
    {
        public readonly Context Context;
        public studentRepository(Context context) : base(context)
        {
            Context = context;
        }

        public async Task<StudentDTO> GetStudentsubject(string studentId, string include)
        {
            var query = await Context.RequestAppointments
                .Include(r => r.Request)
                .ThenInclude(r => r.Student).ThenInclude(r => r.ApplicationUser)
                .Where(r => r.Request.StudentID == studentId)
                .Include(r => r.CustomAppointment)
                .ThenInclude(r => r.InstructorSubjectBridge)
                .ThenInclude(r => r.Subject)
                .FirstOrDefaultAsync();

            if (query == null)
            {

                return null;
            }

            return new StudentDTO
            {
                Id = query.Request.Student.ApplicationUser.Id,
                Name = query.Request.Student.ApplicationUser.Name,
                Email = query.Request.Student.ApplicationUser.Email,
                Phone = query.Request.Student.ApplicationUser.PhoneNumber,
                Numberofhours = (int)query.Request.NumberOfHouers,
                Subjects = new List<string> { query.CustomAppointment.InstructorSubjectBridge.Subject.Name }

            };
        }

        public async Task<List<TutorialResponseDto>> GetTutorial(string studentId)
        {
            var res = await Context.Tutorials.Where(t => t.StudentId == studentId).ToListAsync();

            var res2 = await Context.SubjectTutorial.Where(st => res.Select(s => s.Id).Contains(st.Id))
                .Include(s => s.Tutorial)
                .ThenInclude(s => s.InstructorSubject)
                .ThenInclude(s => s.Instructor)
                .ThenInclude(s => s.applicationUser)
                .Include(s => s.Tutorial)
                .ThenInclude(s => s.InstructorSubject)
                .ThenInclude(s => s.Subject)
                .Select(s => new TutorialResponseDto
                {
                    InstructorName = s.Tutorial.InstructorSubject.Instructor.applicationUser.Name,
                    SubjectName = s.Tutorial.InstructorSubject.Subject.Name,
                    Tutorial = s.subjectTutorial,
                    TutorialType = s.TutorialType,
                }).ToListAsync();

            return res2;
        }
        public async Task<List<TutorialResponse2Dto>> GetTutorial2(string studentId)
        {
            var res = await Context.Tutorials.Where(t => t.StudentId == studentId).ToListAsync();

            var result = await Context.SubjectTutorial
                                     .Where(st => res.Select(s => s.Id).Contains(st.Id))
                                     .Include(s => s.Tutorial)
                                     .ThenInclude(s => s.InstructorSubject)
                                     .ThenInclude(s => s.Instructor)
                                     .ThenInclude(s => s.applicationUser)
                                     .Include(s => s.Tutorial)
                                     .ThenInclude(s => s.InstructorSubject)
                                     .ThenInclude(s => s.Subject)
                                     .GroupBy(s => new
                                     {
                                         StudentName = s.Tutorial.InstructorSubject.Instructor.applicationUser.Name,
                                         InstructorName = s.Tutorial.InstructorSubject.Instructor.applicationUser.Name,
                                         SubjectName = s.Tutorial.InstructorSubject.Subject.Name

                                     })
                                     .Select(group => new TutorialResponse2Dto
                                     {
                                         SubjectName = group.Key.SubjectName,
                                         InstructorName = group.Key.InstructorName,
                                         TutorialDatas = group.Select(s => new TutorialData
                                         {
                                             subjectTutorial = s.subjectTutorial,
                                             TutorialType = s.TutorialType,
                                         }).ToList()
                                     })
                                     .ToListAsync();
            return result;

        }
    }
}

