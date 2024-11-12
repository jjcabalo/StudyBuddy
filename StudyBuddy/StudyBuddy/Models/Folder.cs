using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudyBuddy.Models
{
    public class Folder
    {
        [Key]
        public int FolderId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student? Student { get; set; }

        [Required]
        public string? Name { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
