using OnlineCours.Models;

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
}
