using OnlineCours.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCours.DTO
{
    public class UniveristyRequestDTO
    {
        /// <summary>
        /// ////////
        /// </summary>
        public int? Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string? File { get; set; }

        public string StudentID { get; set; }
    }
}
