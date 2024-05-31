using System.ComponentModel.DataAnnotations;

namespace jobconnect.Dtos
{
    public class ShowProposalDto
    {
            [Required]
            public int JobId { get; set; }
            [Required]
            public int JobSeekerId { get; set; }
            [Required]
            public string? brief_description { get; set; }
       
            public IFormFile CV_file { get; set; } //update it


    }
}
