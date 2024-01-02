using OCTW.Server.Repository;
using OnlineCours.Models;

namespace OnlineCours.Repository
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        public Task<List<Subject>> GetSubjectsByStudent(string StudentId);

    }
}
