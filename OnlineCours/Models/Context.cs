﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<StudentSubjectBridge> StudentSubjects { get; set; }

        //public DbSet<Semester> Semesters { get; set; }
        //public DbSet<InstructorLevelBridge> InstructorLevels { get; set; }
        //public DbSet<Level> Levels { get; set; }

    }
}
