using OnlineCours.Models;

namespace OnlineCours.DTO
{
    public class UploadTutorialModel
    {
        public string StudentId { get; set; }
        public string InstructorId { get; set; }
        public int SubjcetId { get; set; }
        public List<TutorialData> Tutorial {  get; set; }
        public string TutorialName { get; set; }

    }
    public class TutorialData 
    {
        public string subjectTutorial { get; set; }
        public TutorialType TutorialType { get; set; }
    }
}
