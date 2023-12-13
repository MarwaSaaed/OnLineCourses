using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCours.Models
{
    public class Request : BaseClase
    {
        public Grade Grade { get; set; }
        public string SubjectName { get; set; }

        // عدد الساعات مختلفه عن الايام والساعات بتاعت الانستراكتور
        public int NumberOfHouers { get; set; }

        [ForeignKey("Instructor")]
        public string InstructorID { get; set; }
        public Instructor Instructor { get; set; }

        public List<StudentRequest>? StudentRequests { get; set; }
    }
}
