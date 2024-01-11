using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;

namespace OnlineCours.Models
{
    public class Context :IdentityDbContext<ApplicationUser>
    {

        public Context() { }
        public Context(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<OtherRequest> ConsultingRequest { get; set; }
        public DbSet<CourseRequest> CoursesRequest { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<CustomAppointment> CustomAppointments { get; set; }
        public DbSet<RequestAppointment> RequestAppointments { get; set; }
        public DbSet<InstructorSubjectBridge> InstructorSubjects { get; set; }
        public DbSet<Tutorial> Tutorials { get; set; }
        public DbSet<SubjectTutorial> SubjectTutorial { get; set; }
        /// <summary>
        /// ////////
        /// </summary>
        public DbSet<UniveristyRequest> univeristyRequests { get; set; }


    }
}
