using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCours.Models
{
   
    public class Student
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public List<UniveristyRequest> univeristyRequests { get; set; } 
    }
}
