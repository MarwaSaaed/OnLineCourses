using OCTW.Server.Repository;
using OnlineCours.DTO;
using OnlineCours.Models;

namespace OnlineCours.Repository
{
    public interface IUniveristyRequestRepositry:IRepository<UniveristyRequest>
    {
        Task<List<UniveristyStudentRequestDTO>> GetUniveristyRequest();

    }
    /// <summary>
    /// ////////
    /// </summary>
}
