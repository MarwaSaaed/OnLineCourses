using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCours.Models
{
    public class Subject : BaseClase
    {
        public string Name { get; set; }
        public Grade Grade { get; set; }

        public List<InstructorSubjectBridge>? InstructorSubjectBridge { get; set; }
    }
}
