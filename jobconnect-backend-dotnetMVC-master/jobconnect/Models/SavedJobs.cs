using System.ComponentModel.DataAnnotations;
namespace jobconnect.Models
{
    public class SavedJobs
    {
        //JobSeekerId is ForeignKey
        //JobId is ForeignKey
        //UserId + JobId are composite primary key
        // This relation is set on DataContext class
        public int JobSeekerId { get; set; }
        
        public JobSeeker JobSeeker { get; set; }
        public int JobId { get; set; }

        public Job Job { get; set; }
    }
}
