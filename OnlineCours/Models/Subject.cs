using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCours.Models
{
    public class Subject :BaseClase
    {
        //Menaaaaaa

        public string Name { get; set; }
        [ForeignKey("Levels")]
        public int  LevelID { get; set; }
        public Level? Levels { get; set; }
        public List<Appointment> appointments { get; set; }
     }
}
