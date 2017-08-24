using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityManagement.Domain.Entities;

namespace UniversityManagement.Infrastructure.Database
{
    public class UniversityManagementContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:UniversityManagement.Infrastructure.Database.UniversityManagementContext"/> class.
        /// </summary>
        /// <param name="options">Options.</param>
        public UniversityManagementContext(DbContextOptions<UniversityManagementContext> options) : base(options)
        {
            
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Lecture> Lecture { get; set; }
        public DbSet<LectureTheatre> LectureTheatre { get; set; }
        public DbSet<Enrolment> Enrolment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(ConfigureStudent);
            modelBuilder.Entity<Subject>(ConfigureSubject);
            modelBuilder.Entity<Lecture>(ConfigureLecture);
            modelBuilder.Entity<LectureTheatre>(ConfigureLectureTheatre);
            modelBuilder.Entity<Enrolment>(ConfigureEnrolment);
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
            builder
                .ToTable("Subject")
                .HasKey(x=> x.Id);

            builder
                .HasMany(x=> x.Lectures)
                .WithOne(y=> y.Subject);
        }
        
        void ConfigureLecture(EntityTypeBuilder<Lecture> builder)
        {
            builder
                .ToTable("Lecture")
                .HasKey(x => x.Id);

            builder
                .HasOne(x => x.Subject)
                .WithMany(y => y.Lectures);

			builder
				.HasOne(x => x.LectureTheatre)
				.WithOne(y => y.Lecture)
				.HasForeignKey<LectureTheatre>(p => p.LectureId);
        }
        
        void ConfigureLectureTheatre(EntityTypeBuilder<LectureTheatre> builder)
        {
            builder
                .ToTable("LectureTheatre")
                .HasKey(x=>x.Id);
            /*
            builder
                .HasOne(x => x.Lecture)
                .WithOne(y => y.LectureTheatre)
                .HasForeignKey<Lecture>(f => f.LectureTheatreId);
             */
        }
        
        void ConfigureEnrolment(EntityTypeBuilder<Enrolment> builder)
        {
            builder
                .ToTable("Enrolment")
                .HasKey(x=> x.Id);
            builder
                .HasOne(x=>x.Student)
                .WithMany(y=> y.Enrolments);
            
        }
        
    }
}