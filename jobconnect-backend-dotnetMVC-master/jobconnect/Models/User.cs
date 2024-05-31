using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jobconnect.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        public string UserType { get; set; }

        public JobSeeker JobSeeker { get; set; }

        public Employer Employer { get; set; }
    }
}
