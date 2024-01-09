namespace OnlineCours.Models
{
    public class SubjectTutorial :BaseClase
    {
        public string subjectTutorial { get; set; }
        public int TutorialId{ get; set; }
        public TutorialType TutorialType{ get; set; }

        public Tutorial Tutorial { get; set; }
    }



    public enum TutorialType
    {
        Vedio=1,
        PDF = 2,
        Photo = 4,
    }
}
