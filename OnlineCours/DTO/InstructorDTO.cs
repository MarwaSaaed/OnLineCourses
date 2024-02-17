using OnlineCours.Models;

namespace OnlineCours.DTO
{
    public class InstructorDTO
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? InstructorID { get; set; }
        public int? InstructorSubjectBridgeID { get; set; }
        public StatusOfInstructor status { get; set; }
        public List<AppoinstmentDTO>? Appointments { get; set; }
        public List<string>? Subjects { get; set; }

    }

    public class InstructorSubjectsAndAppointmentDTO
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string? InstructorID { get; set; }
        public int? InstructorSubjectBridgeID { get; set; }
        public List<SubjectAppoinstmentDTO>? SubjectsAppointments { get; set; }
    }


}
