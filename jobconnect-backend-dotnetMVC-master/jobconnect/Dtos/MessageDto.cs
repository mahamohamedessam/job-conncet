using System.ComponentModel.DataAnnotations;

namespace jobconnect.Dtos
{
    public class MessageDto
    {

        [Required]
        public int FromId { get; set; }
        [Required]
        public int ToId { get; set; }
        [Required]
        public string Content { get; set; }

    }
}
