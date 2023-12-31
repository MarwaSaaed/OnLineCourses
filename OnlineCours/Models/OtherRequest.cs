namespace OnlineCours.Models
{
    public class OtherRequest : BaseClase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string File { get; set; }
        public string? ConsultingHoures { get; set; }
        public OtherRequests OtherRequests { get; set; }

    }
}
