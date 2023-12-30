using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCours.Models
{
    public class Request : BaseClase
    {
        public string Grade { get; set; }
        public int? NumberOfHouers { get; set; }
        public StatusOfStudent status { get; set; } = StatusOfStudent.Pendding;


        [ForeignKey("Student")]
        public string StudentID { get; set; }
        public Student? Student { get; set; }

    }
}
