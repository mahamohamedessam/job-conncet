using System.ComponentModel.DataAnnotations;


namespace jobconnect.Dtos
{
    public class EmployerDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Company_name { get; set; }

        [Required]
        public string Company_description { get; set; }

        [Required]
        public string mainaddress { get; set; }
    }
}


