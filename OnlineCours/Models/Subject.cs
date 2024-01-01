using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OnlineCours.Models
{
    [Index("Name", IsUnique = true)]

    public class Subject : BaseClase
    {
        public string Name { get; set; }
        public Grade Grade { get; set; }

        [JsonIgnore]
        public List<InstructorSubjectBridge>? InstructorSubjectBridge { get; set; }
    }
}
