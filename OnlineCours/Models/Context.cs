using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<StudentSubjectBridge> StudentSubjects { get; set; }


    }
}
