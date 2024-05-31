using System.ComponentModel.DataAnnotations;

namespace jobconnect.Dtos
{
    public class ShowJobDto
    {

        [Required]
        [StringLength(50)] //max length of 50 characters
        public string Job_title { get; set; }
        public string? Job_description { get; set; }

        [Required]
        public string Job_type { get; set; } // A field to set if job is (part time, full time,or remote)

        [Required]
        public string location { get; set; }

        [Required]
        public string industry { get; set; }

        [Required]
        public string salary_budget { get; set; }

        [Required]
        public int No_of_position_required { get; set; }

 
        public int EmpId { get; set; } // Employer_id
   

    }

}
