﻿using OnlineCours.Models;
using System.Diagnostics.Contracts;

namespace OnlineCours.DTO
{
    public class RequestDTO
    {

    }
    public class StudentRequestToTakeSubject 
    {
        public string Grade { get; set; }
        public string SubjectName { get; set; }
        public string StudentId { get; set; }
        public int NumberOfHouers { get; set; }
        public string InstructorId { get; set; }
        public int SubjectId { get; set; }
        public List<AppoinstmentDTO> Appoinstments { get; set; }


    }
    public class StudentRequestForInstructor
    {
        public int RequestId { get; set; }
        public string StudentName { get; set; }
        public string Grade { get; set; }
        public string SubjectName { get; set; }
        public DateTime LectureDate { get; set; }
        public Day DayOfWeek { get; set; }
    }
}
