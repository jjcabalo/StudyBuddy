using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudyBuddy.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public string StudentCode { get; set; }

        public int StudyHours { get; set; }

        public bool StudyMode { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
