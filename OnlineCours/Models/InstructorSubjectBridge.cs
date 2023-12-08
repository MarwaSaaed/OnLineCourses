namespace OnlineCours.Models
{
    public class InstructorSubjectBridge : BaseClase
    {
        public List<Instructor> Instructors { get; set; }
        public List<Subject> Subject { get; set; }
        public List<Appointment> appointments { get; set; }

    }
}
