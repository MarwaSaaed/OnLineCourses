using OCTW.Server.Repository;
using OnlineCours.Models;

namespace OnlineCours.Repository
{
    public class OtherRequestRepositry : Repository<OtherRequest>, IOtherRequestRepositry
    {
        private readonly Context context;

        public OtherRequestRepositry(Context context) : base(context)
        {
            this.context = context;
        }
    }
}
