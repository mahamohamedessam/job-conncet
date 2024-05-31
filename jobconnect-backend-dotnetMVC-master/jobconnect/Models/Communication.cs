using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace jobconnect.Models
{
    public class Communication
    {
        [Key]
        public int CommunicationId { get; set; }

        [ForeignKey("JobSeeker")]
        public int JobSeekerId { get; set; }
        public JobSeeker JobSeeker { get; set; } // navigation to JobSeeker

        [ForeignKey("Employer")]
        public int EmployerId { get; set; }
        public Employer Employer { get; set; } // navigation to employer
        public List<Messages> Messages { get; set; }


    }
}

