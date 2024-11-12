using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudyBuddy.Models
{
    public class ParentStudentLink
    {
        [Key]
        public int LinkId { get; set; }

        [ForeignKey("Parent")]
        public int ParentId { get; set; }
        public Parent? Parent { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student? Student { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
