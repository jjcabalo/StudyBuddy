using System.ComponentModel.DataAnnotations;

namespace StudyBuddy.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        public char? MiddleInitial { get; set; }

        public string Suffix { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string UserType { get; set; }  // "student" or "parent"

        public string ResetToken { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? LastLogin { get; set; }

        public bool Verified { get; set; }
    }
}
