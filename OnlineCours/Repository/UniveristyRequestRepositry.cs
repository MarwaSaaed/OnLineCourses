using Microsoft.EntityFrameworkCore;
using OCTW.Server.Repository;
using OnlineCours.DTO;
using OnlineCours.Models;

namespace OnlineCours.Repository
{
    public class UniveristyRequestRepositry : Repository<UniveristyRequest>, IUniveristyRequestRepositry
    {
        private readonly Context context;

        public UniveristyRequestRepositry(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<UniveristyStudentRequestDTO>> GetUniveristyRequest()
        {
            var requests =await context.univeristyRequests
                .Where(z=>z.Status==StatusOfStudent.Pendding).Include(x => x.Student)
                .ThenInclude(y => y.ApplicationUser)
                .Select(z =>
                new UniveristyStudentRequestDTO
                {
                    StudentName = z.Student.ApplicationUser.Name,
                    StudentId = z.StudentID,
                    Phone=z.Student.ApplicationUser.PhoneNumber,
                    UniveristyRequest = new UniveristyRequestDTO
                    {
                        Id = z.Id,
                        Name = z.Name,
                        Description = z.Description,
                        File = z.File,
                        StudentID = z.StudentID
                    }
                }
                ).ToListAsync();
            return requests;
        }
    }
}
