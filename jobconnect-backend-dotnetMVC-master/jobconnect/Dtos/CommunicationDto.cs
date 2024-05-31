using System.ComponentModel.DataAnnotations;

namespace jobconnect.Dtos
  {
     public class CommunicationDto
     {
        [Required]
        public int JobSeekerId { get; set; }

        [Required]
        public int EmployerId { get; set; }

     }
}

    

