﻿using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCours.Models
{
    public enum Day
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }
    public enum Status
    {
        OnTime,
        Late,
        Delete
    }
    public class Appointment :BaseClase
    {
        //Menaaaaaa

        public DateTime LectureDate { get; set; }
        public Day DayOfWeek { get; set;}
        public Status Status { get; set;}

        [ForeignKey("InstructorSubjectBridge")]
        public int InstructorSubjectBridgeID { get; set; }
        public InstructorSubjectBridge InstructorSubjectBridge { get; set; }


    }
}
