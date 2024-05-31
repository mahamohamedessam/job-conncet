using System.ComponentModel.DataAnnotations;

namespace jobconnect.Dtos
{
    public class JobSeekerDto
    {
        //[Required]
        public string Username { get; set; } //remove username
        public string first_name { get; set; } //firstName

        public string last_name { get; set; } //lastName

        public string Email { get; set; }

        [Required]
        public string Password { get; set; }


        //public string? image { get; set; }

        public string? latest_certificate { get; set; } //High school, bachelor, master, phd

        //[Required]
        public int gender { get; set; }

        //[Required]
        public string phone { get; set; }

    }
}
