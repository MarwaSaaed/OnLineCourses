using OCTW.Server.Repository;
using OnlineCours.Models;

namespace OnlineCours.Repository
{
    public class RequestRepository : Repository<Request>, IRequestRepository
    {
        public RequestRepository(Context context) : base(context)
        {

        }
    }
}
