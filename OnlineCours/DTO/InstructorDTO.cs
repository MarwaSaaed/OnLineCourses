using OnlineCours.Models;

namespace OnlineCours.DTO
{
    public class InstructorDTO
    {
        public string Name { get; set; }
        public string? InstructorID { get; set; }
        public StatusOfInstructor status { get; set; }
        public List<AppoinstmentDTO>? Appointments { get; set; }
        public List<string>? Subjects { get; set; }

    }
}
