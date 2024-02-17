using OnlineCours.Models;

namespace OnlineCours.DTO
{
    public class AppoinstmentDTO
    {
        public int? Id { get; set; }
        public string LectureDate { get; set; }
        public string DayOfWeek { get; set; }
    }
    public class EditAppointmentModel
    {
        public string LectureDate { get; set; }
        public string DayOfWeek { get; set; }
    }

    public class SubjectAppoinstmentDTO
    {
        public string SubjectsName { get; set; }
        public List<AppoinstmentDTO>? Appointments { get; set; }

    }
}
