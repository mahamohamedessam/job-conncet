using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jobconnect.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }

        [Required]
        [StringLength(50)] //max length of 50 characters
        public string Job_title { get; set; }
        public string Job_description { get; set;}

        [Required]
        public string Job_type { get; set;} // A field to set if job is (part time, full time,or remote)
        
        
        [Required]
        public DateTime Post_creation_date { get; set; }//updaate Post_creation_date in data as DateTime

        [Required]
        public string location { get; set; }

        [Required]
        public string industry { get; set; }

        [Required]
        public string salary_budget { get; set; }

        public int? No_of_proposal_submitted { get; set; }

        [Required]
        public int No_of_position_required { get; set; }

        [Required]
        public bool Accepted_by_admin { get; set; } = false;


        [ForeignKey("Employer")]
        public int EmpId { get; set; } // Employer_id
        public Employer Employer { get; set; } // navigation to employer (owner of job)
 

        public ICollection<Proposal> Proposal { get; set; }  // list of proposals for a particular job

        public ICollection<SavedJobs> SavedJobs { get; set; }
    }
}
