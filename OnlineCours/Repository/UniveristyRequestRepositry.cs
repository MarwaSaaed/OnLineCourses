using OCTW.Server.Repository;
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
    }
}
