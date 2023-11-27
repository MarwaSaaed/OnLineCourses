using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCours.Models
{
    public enum DayOfWeek
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }
    public enum Stutes
    {
        OnTime,
        Late,
        Delete
    }
    public class Appointment :BaseClase
    {
        //Menaaaaaa

        public DateTime LectureDate { get; set; }
        public DayOfWeek DayOfWeek { get; set;}
        public Stutes stutes { get; set;}

        [ForeignKey("subject")]
        public int subjectID { get; set; }
        public Subject? subject { get; set; }
        
       
    }
}
