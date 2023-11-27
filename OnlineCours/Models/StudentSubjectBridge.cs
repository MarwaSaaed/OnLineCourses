using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCours.Models
{
    public class StudentSubjectBridge :BaseClase
    {
        //Marwa
        [ForeignKey("subject")]
        public int SubjectID { get; set; }
        public Subject? subject { get; set; }

        [ForeignKey("student")]
        public string StudentID { get; set; }
        public Student? student { get; set; }

        public List<Appointment> appointments { get; set; }

    }
}
