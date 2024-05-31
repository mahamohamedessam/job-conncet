using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace jobconnect.Models
{
    public class Messages
    {
        [Key]
        public int MessageId { get; set; }

        [ForeignKey("Communication")]
        public int CommunicationId { get; set; }
        public Communication Communication { get; set; } // navigation to Communication

        [Required]
        public int FromId { get; set; }
        [Required]
        public int ToId { get; set; }

        [Required]
        public string Content { get; set; }
         [Required]
     
        public DateTime Message_date { get; set; }

}
}

