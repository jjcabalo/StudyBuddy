using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudyBuddy.Models
{
    public class Parent
    {
        [Key]
        public int ParentId { get; set; }

        [Required]
        public string ParentCode { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
