using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityManagement.Domain.Entities;

namespace UniversityManagement.Infrastructure.Database
{
    public class UniversityManagementContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Lecture> Lecture { get; set; }
        public DbSet<LectureTheatre> LectureTheatre { get; set; }
        public DbSet<Enrolment> Enrolment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>();
            modelBuilder.Entity<Subject>();
            modelBuilder.Entity<Lecture>();
            modelBuilder.Entity<LectureTheatre>();
            modelBuilder.Entity<Enrolment>();
        }

        void ConfigureStudent(EntityTypeBuilder<Student> builder)
        {
            builder
                .ToTable("Student")
                .HasKey(x => x.Id);


            builder
                .Property(x => x.Id)
                .ForSqlServerUseSequenceHiLo("student_hilo");
        }
        
        void ConfigureSubject(EntityTypeBuilder<Subject> builder)
        {
            
        }
        
        void ConfigureLecture(EntityTypeBuilder<Lecture> builder)
        {
            
        }
        
        void ConfigureLectureTheatre(EntityTypeBuilder<LectureTheatre> builder)
        {
            
        }
        
        void ConfigureEnrolment(EntityTypeBuilder<Enrolment> builder)
        {
            
        }
        
    }
}