using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudyBuddy.Models
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Required]
        public string Title { get; set; }

        public string Content { get; set; }

        public string FilePath { get; set; }

        public string FileType { get; set; }

        public int? FileSize { get; set; }

        [ForeignKey("Folder")]
        public int? FolderId { get; set; }
        public Folder Folder { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastModified { get; set; }
    }
}
