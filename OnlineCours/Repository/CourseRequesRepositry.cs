using OCTW.Server.Repository;
using OnlineCours.Models;

namespace OnlineCours.Repository
{
    public class CourseRequesRepositry : Repository<CourseRequest>, ICourseRequesRepositry
    {
        private readonly Context context;

        public CourseRequesRepositry(Context context) : base(context)
        {
            this.context = context;
        }
    }
}
