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
        public ApplicationUser applicationUser { get; set; }
        public StatusOfInstructor status { get; set; } = StatusOfInstructor.Pendding;

        public List<InstructorSubjectBridge>? InstructorSubjectBridge { get; set; }
    }
}
