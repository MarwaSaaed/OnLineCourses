using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCours.Models
{
    public class Subject :BaseClase
    {
        //Menaaaaaa
        public string Name { get; set; }
        public Grade Grade { get; set; }
        public Semester Semester { get; set; }

        [ForeignKey("InstructorSubjectBridge")]
        public int InstructorSubjectBridgeID { get; set; }
        public InstructorSubjectBridge InstructorSubjectBridge { get; set; }


        //public Level? Levels { get; set; }
    }
}
