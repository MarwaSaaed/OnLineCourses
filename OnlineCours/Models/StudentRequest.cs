using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCours.Models
{
    public class StudentRequest : BaseClase
    {

        [ForeignKey("Student")]
        public string StudentID { get; set; }
        public Student Student { get; set; }
        

        [ForeignKey("Request")]
        public string RequestID { get; set; }
        public Request Request { get; set; }

        public StatusOfStudent status { get; set; } = StatusOfStudent.Pendding;

    }
}
