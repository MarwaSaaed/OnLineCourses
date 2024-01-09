namespace OnlineCours.Models
{
    public class Tutorial :BaseClase
    {
         public string Name { get; set; }
         public int InstructorSubjectId { get; set; }
        public string StudentId { get; set; }
        public virtual InstructorSubjectBridge InstructorSubject { get; set; }
        public virtual Student Student { get; set; }

        

    }
}
