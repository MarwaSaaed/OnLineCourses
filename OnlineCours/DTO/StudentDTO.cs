namespace OnlineCours.DTO
{
    public class StudentDTO
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int Numberofhours { get; set; }

        public List<string>? Subjects { get; set; }
    }
}
