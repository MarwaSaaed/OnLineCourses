namespace OnlineCours.DTO
{
    public class InstructorSubjectDTO
    {
        public string InstructorId { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public List<AppoinstmentDTO> AppoinstmentDTOs { get; set; }
    }

    public class AddSubjectRequest 
    {

        public int? Id { get; set; }
        public string Name { get; set; }
        public Grade Grade { get; set; }
        

    }

    public class studentliberary
    {

        public int? Id { get; set; }
        public string SubjectName { get; set; }
        public string InstractorName { get; set; }



    }
}

