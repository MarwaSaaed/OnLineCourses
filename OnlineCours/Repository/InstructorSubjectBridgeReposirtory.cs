using OCTW.Server.Repository;
using OnlineCours.Models;

namespace OnlineCours.Repository
{
    public class InstructorSubjectBridgeReposirtory : Repository<InstructorSubjectBridge>, IInstructorSubjectBridgeRepository
    {
        public InstructorSubjectBridgeReposirtory(Context context) : base(context)
        {
        }
    }
}
