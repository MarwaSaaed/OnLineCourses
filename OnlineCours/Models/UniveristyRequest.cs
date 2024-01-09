using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCours.Models
{
    public class UniveristyRequest:BaseClase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? File { get; set; }
        public StatusOfStudent Status { get; set; } = StatusOfStudent.Pendding;

        [ForeignKey("Student")]
        public string StudentID { get; set; }
        public Student? Student { get; set; }

    }
}
