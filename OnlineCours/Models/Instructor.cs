using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCours.Models
{
    public enum StatusOfInstructor
    {
        Pendding,
        Accepted,
        Rejected
    }
    public class Instructor 
    {
        [Key]
        [ForeignKey("applicationUser")]
        public string applicationUserID { get; set; }

        [ForeignKey("InstructorSubjectBridge")]
        public int InstructorSubjectBridgeID { get; set; }

        public ApplicationUser applicationUser { get; set; }
        public InstructorSubjectBridge InstructorSubjectBridge { get; set; }
        public StatusOfInstructor status { get; set; } = StatusOfInstructor.Pendding;

    }
}
