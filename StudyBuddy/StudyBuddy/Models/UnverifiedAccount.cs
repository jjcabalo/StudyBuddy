using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudyBuddy.Models
{
    public class UnverifiedAccount
    {
        [Key]
        public int AccountId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public string VerificationToken { get; set; }

        public DateTime TokenExpiry { get; set; }
    }
}
