using OnlineCours.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCours.DTO
{
    public class RequestAppointmentDTO
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public string StudentName { get; set; }
        public string StudentPhoneNumber { get; set; }
        public string StudentEmail { get; set; }
        public string Grade { get; set; }
        public int? NumberOfHouers { get; set; }
        public StatusOfStudent status { get; set; }

        public string InstructorName { get; set; }

    }
}
