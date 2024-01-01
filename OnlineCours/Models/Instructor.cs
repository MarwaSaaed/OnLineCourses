using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        public ApplicationUser? applicationUser { get; set; }
        public StatusOfInstructor status { get; set; } = StatusOfInstructor.Pendding;
        [JsonIgnore]
        public List<InstructorSubjectBridge>? InstructorSubjectBridge { get; set; }
    }
}
