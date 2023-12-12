using OnlineCours.Models;

namespace OnlineCours.DTO
{
    public class InstructorDTO
    {
        public StatusOfInstructor status { get; set; }
        public string Name { get; set; }
        public List<Day> Appointments { get; set; }
        public List<string> Subjects { get; set; }

    }
}
