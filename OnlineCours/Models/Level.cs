using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCours.Models
{
    public class Level :BaseClase
    {
        //Marwa

        public string Name { get; set; }
        public List<Semester> semesters { get; set; }

    }
}
