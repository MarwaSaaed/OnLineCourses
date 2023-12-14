using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCours.Models
{
    public class RequestAppointment : BaseClase
    {
        [ForeignKey("Request")]
        public int RequestID { get; set; }
        public Request? Request { get; set; }
        

        [ForeignKey("Appointment")]
        public int AppointmentID { get; set; }
        public Appointment? Appointment { get; set; }
    }
}
