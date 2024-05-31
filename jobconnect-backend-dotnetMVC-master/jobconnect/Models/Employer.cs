using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace jobconnect.Models
{
    public class Employer
    {
        [Key]
        [ForeignKey("User")]     
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployerId { get; set; }

        public User User { get; set; } //navigation to user

        public string? Company_name { get; set; }

        public string? Company_description { get; set; }

        public string? mainaddress { get; set; }

        public ICollection<Job> Job { get; set; }  // list of jobs for a particular employer

        public ICollection<Communication> Communication { get; set; } // list of communication(Chats) that employer have
    }
}
