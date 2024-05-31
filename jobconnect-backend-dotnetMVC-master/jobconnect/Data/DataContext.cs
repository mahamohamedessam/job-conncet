using jobconnect.Models;
using Microsoft.EntityFrameworkCore;

namespace jobconnect.Data
{
    public class DataContext : DbContext
    {
        internal readonly object Jobs;

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> User { get; set; }

        public DbSet<Employer> Employer { get; set; }

        public DbSet<JobSeeker> JobSeeker { get; set; }

        public DbSet<Job> Job { get; set; }

        public DbSet<Proposal> Proposal { get; set; }

        public DbSet<SavedJobs> SavedJobs { get; set; }

        public DbSet<Communication> Communication { get; set; }

        public DbSet<Messages> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proposal>().HasKey(sc => new { sc.JobSeekerId, sc.JobId });
            modelBuilder.Entity<Proposal>()
                .HasOne(sc => sc.JobSeeker)
                .WithMany(s => s.Proposal)
                .HasForeignKey(sc => sc.JobSeekerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Proposal>()
                .HasOne(sc => sc.Job)
                .WithMany(c => c.Proposal)
                .HasForeignKey(sc => sc.JobId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SavedJobs>().HasKey(sc => new { sc.JobSeekerId, sc.JobId });
            modelBuilder.Entity<SavedJobs>()
                .HasOne(sc => sc.JobSeeker)
                .WithMany(s => s.SavedJobs)
                .HasForeignKey(sc => sc.JobSeekerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SavedJobs>()
                .HasOne(sc => sc.Job)
                .WithMany(c => c.SavedJobs)
                .HasForeignKey(sc => sc.JobId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Communication>().HasKey(sc => new { sc.CommunicationId });
            modelBuilder.Entity<Communication>()
                .HasOne(sc => sc.JobSeeker)
                .WithMany(s => s.Communication)
                .HasForeignKey(sc => sc.JobSeekerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Communication>()
                .HasOne(sc => sc.Employer)
                .WithMany(c => c.Communication)
                .HasForeignKey(sc => sc.EmployerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
