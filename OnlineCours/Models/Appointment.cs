using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCours.Models
{
    public enum Day
    {
        الاحد,
        الاثنين,
        الثلاثاء,
        الاربعاء,
        الخميس,
        الجمعه,
        السبت
    }
    public enum Status
    {
        OnTime,
        Late,
        Canceled,
    }
    public class Appointment : BaseClase
    {
        public string LectureDate { get; set; }
        public Day DayOfWeek { get; set; }
        public Status? Status { get; set; }

        [ForeignKey("InstructorSubjectBridge")]
        public int InstructorSubjectBridgeID { get; set; }
        public InstructorSubjectBridge InstructorSubjectBridge { get; set; }
    }
}
