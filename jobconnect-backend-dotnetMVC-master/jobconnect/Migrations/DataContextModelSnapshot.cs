﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using jobconnect.Data;

#nullable disable

namespace jobconnect.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("jobconnect.Models.Communication", b =>
                {
                    b.Property<int>("CommunicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommunicationId"));

                    b.Property<int>("EmployerId")
                        .HasColumnType("int");

                    b.Property<int>("JobSeekerId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommunicationId");

                    b.HasIndex("EmployerId");

                    b.HasIndex("JobSeekerId");

                    b.ToTable("Communication");
                });

            modelBuilder.Entity("jobconnect.Models.Employer", b =>
                {
                    b.Property<int>("EmployerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Company_description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mainaddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployerId");

                    b.ToTable("Employer");
                });

            modelBuilder.Entity("jobconnect.Models.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobId"));

                    b.Property<bool>("Accepted_by_admin")
                        .HasColumnType("bit");

                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.Property<string>("Job_description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Job_title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Job_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("No_of_position_required")
                        .HasColumnType("int");

                    b.Property<int?>("No_of_proposal_submitted")
                        .HasColumnType("int");

                    b.Property<DateTime>("Post_creation_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("industry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("salary_budget")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobId");

                    b.HasIndex("EmpId");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("jobconnect.Models.JobSeeker", b =>
                {
                    b.Property<int>("JobSeekerId")
                        .HasColumnType("int");

                    b.Property<string>("first_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("gender")
                        .HasColumnType("int");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("latest_certificate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobSeekerId");

                    b.ToTable("JobSeeker");
                });

            modelBuilder.Entity("jobconnect.Models.Proposal", b =>
                {
                    b.Property<int>("JobSeekerId")
                        .HasColumnType("int");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("CV_file")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Proposal_date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("accepted_by_emp")
                        .HasColumnType("bit");

                    b.Property<string>("brief_description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobSeekerId", "JobId");

                    b.HasIndex("JobId");

                    b.ToTable("Proposal");
                });

            modelBuilder.Entity("jobconnect.Models.SavedJobs", b =>
                {
                    b.Property<int>("JobSeekerId")
                        .HasColumnType("int");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.HasKey("JobSeekerId", "JobId");

                    b.HasIndex("JobId");

                    b.ToTable("SavedJobs");
                });

            modelBuilder.Entity("jobconnect.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("jobconnect.Models.Communication", b =>
                {
                    b.HasOne("jobconnect.Models.Employer", "Employer")
                        .WithMany("Communication")
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("jobconnect.Models.JobSeeker", "JobSeeker")
                        .WithMany("Communication")
                        .HasForeignKey("JobSeekerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employer");

                    b.Navigation("JobSeeker");
                });

            modelBuilder.Entity("jobconnect.Models.Employer", b =>
                {
                    b.HasOne("jobconnect.Models.User", "User")
                        .WithOne("Employer")
                        .HasForeignKey("jobconnect.Models.Employer", "EmployerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("jobconnect.Models.Job", b =>
                {
                    b.HasOne("jobconnect.Models.Employer", "Employer")
                        .WithMany("Job")
                        .HasForeignKey("EmpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employer");
                });

            modelBuilder.Entity("jobconnect.Models.JobSeeker", b =>
                {
                    b.HasOne("jobconnect.Models.User", "User")
                        .WithOne("JobSeeker")
                        .HasForeignKey("jobconnect.Models.JobSeeker", "JobSeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("jobconnect.Models.Proposal", b =>
                {
                    b.HasOne("jobconnect.Models.Job", "Job")
                        .WithMany("Proposal")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("jobconnect.Models.JobSeeker", "JobSeeker")
                        .WithMany("Proposal")
                        .HasForeignKey("JobSeekerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("JobSeeker");
                });

            modelBuilder.Entity("jobconnect.Models.SavedJobs", b =>
                {
                    b.HasOne("jobconnect.Models.Job", "Job")
                        .WithMany("SavedJobs")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("jobconnect.Models.JobSeeker", "JobSeeker")
                        .WithMany("SavedJobs")
                        .HasForeignKey("JobSeekerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("JobSeeker");
                });

            modelBuilder.Entity("jobconnect.Models.Employer", b =>
                {
                    b.Navigation("Communication");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("jobconnect.Models.Job", b =>
                {
                    b.Navigation("Proposal");

                    b.Navigation("SavedJobs");
                });

            modelBuilder.Entity("jobconnect.Models.JobSeeker", b =>
                {
                    b.Navigation("Communication");

                    b.Navigation("Proposal");

                    b.Navigation("SavedJobs");
                });

            modelBuilder.Entity("jobconnect.Models.User", b =>
                {
                    b.Navigation("Employer")
                        .IsRequired();

                    b.Navigation("JobSeeker")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
