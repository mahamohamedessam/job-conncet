using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jobconnect.Models
{
    public class JobSeeker
    {
        [Key]
        [ForeignKey("User")]
        public int JobSeekerId { get; set; }

        public User User { get; set; } //navigation to user
        public string? first_name { get; set; }

        public string? last_name { get; set; }

        public string? image { get; set; }

        public string? latest_certificate { get; set; } //High school, bachelor, master, phd

        public int gender { get; set; }


        public string? phone { get; set; }

        public ICollection<Proposal> Proposal { get; set; }  // list of proposals for a particular job seeker

        public ICollection<SavedJobs> SavedJobs { get; set; } // list of savedjobs for a particular job seeker

        public ICollection<Communication> Communication { get; set; } // list of communication(Chats) that JobSeeker have
    }
}
