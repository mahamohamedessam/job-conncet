using System.ComponentModel.DataAnnotations;

namespace jobconnect.Dtos
{
    public class ShowEmployerDto
    {
        public int EmployerId { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }

        public string Company_name { get; set; }

        public string Company_description { get; set; }

        public string mainaddress { get; set; }
    }
}
