using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OnlineCours.Models
{
    public class RequestAppointment : BaseClase
    {
        [ForeignKey("Request")]
        public int RequestID { get; set; }
        public Request? Request { get; set; }
        [ForeignKey("CustomAppointment")]
        public int CustomAppointmentID { get; set; }
        public CustomAppointment? CustomAppointment { get; set; }
    }
}
