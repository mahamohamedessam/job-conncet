using System.ComponentModel.DataAnnotations;

namespace jobconnect.Dtos
{
    public class ProposalDto

    {
        [Required]
        public int JobId { get; set; }
        [Required]
        public int JobSeekerId { get; set; }
        [Required]
        public DateTime Proposal_date { get; set; }
        [Required]
        public string? brief_description { get; set; }       
        public string CV_file { get; set; }
        [Required]
        public bool accepted_by_emp { get; set; } = true;
        public string JobSeekerName { get; set; }
    }
}
