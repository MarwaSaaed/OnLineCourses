using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OnlineCours.Models
{
    public class InstructorSubjectBridge : BaseClase
    {
        [ForeignKey("subject")]
        public int SubjectID { get; set; }
        public virtual Subject? Subject { get; set; }


        [ForeignKey("Instructor")]
        public string InstructorID { get; set; }
        public virtual Instructor? Instructor { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
