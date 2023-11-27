using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCours.Models
{
    public enum StutesOfInstructor
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
        public StutesOfInstructor stutes { get; set; } = StutesOfInstructor.Pendding;
    }
}
