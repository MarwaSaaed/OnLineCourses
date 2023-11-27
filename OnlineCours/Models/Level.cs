using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCours.Models
{
    public class Level :BaseClase
    {
        //Marwa

        public string Name { get; set; }
        public List<Subject>  subjects { get; set; }
        [ForeignKey("semester")]
        public int SemesterID { get; set; }
        public Semester? semester { get; set; }

    }
}
