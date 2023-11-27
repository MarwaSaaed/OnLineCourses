using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCours.Models
{
    public enum StutesOfInstudent
    {
        Pendding,
        Accepted,
        Rejected
    }
    public class Student
    {
        //Menaaaaaa

        [Key]
        [ForeignKey("applicationUser")]
        public string applicationUserID { get; set; }
        public ApplicationUser applicationUser { get; set; }
        public StutesOfInstudent stutes { get; set; } = StutesOfInstudent.Pendding;

    }
}
