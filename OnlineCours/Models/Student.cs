using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCours.Models
{
   
    public class Student
    {
        [Key]
        [ForeignKey("applicationUser")]
        public string applicationUserID { get; set; }
        public ApplicationUser applicationUser { get; set; }

        public List<StudentRequest>? StudentRequests { get; set; }
        public List<StudentSubjectBridge>? StudentSubjectBridges { get; set; }
        
    }
}
