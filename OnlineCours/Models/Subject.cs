using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCours.Models
{
    public class Subject :BaseClase
    {
        public string Name { get; set; }

        public List<InstructorSubjectBridge>? InstructorSubjectBridge { get; set; }
        public List<StudentSubjectBridge>? StudentSubjectBridges { get; set; }

    }
}
