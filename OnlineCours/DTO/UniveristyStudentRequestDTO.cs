namespace OnlineCours.DTO
{
    public class UniveristyStudentRequestDTO
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string Phone { get; set; }
        /// <summary>
        /// ////////
        /// </summary>
        public UniveristyRequestDTO UniveristyRequest { get; set; }
    }
}
