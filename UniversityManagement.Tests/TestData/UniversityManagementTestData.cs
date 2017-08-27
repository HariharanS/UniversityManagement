using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Internal;
using UniversityManagement.Domain.Entities;
using UniversityManagement.Infrastructure.Database;

namespace UniversityManagement.Tests.TestData
{
    public class UniversityManagementTestData
    {
        private readonly UniversityManagementContext _dbContext;

        public UniversityManagementTestData(UniversityManagementContext dbContext)
        {
            /*
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<UniversityManagementContext>();
            dbContextOptionsBuilder.UseInMemoryDatabase("University");
            _dbContext = new UniversityManagementContext(dbContextOptionsBuilder.Options);
            */
            _dbContext = dbContext;
        }

        

        public void AddStudentsToDb()
        {
            
            var students = GetStudents();
            _dbContext.Student.AddRange(students);
            _dbContext.SaveChanges();
            //var x = _dbContext.Set<Student>().ToListAsync().Result;
        }

        public void AddLectureTheatresToDb()
        {
            var lectureTheatres = GetLectureTheaters();
            _dbContext.LectureTheatre.AddRange(lectureTheatres);
            _dbContext.SaveChanges();
        }

        public void AddSubjectsToDb()
        {
            var subjects = GetSubjects();
            _dbContext.Subject.AddRange(subjects);
            _dbContext.SaveChanges();
        }

        public static IEnumerable<Student> GetStudents()
        {
            var students = new List<Student>
            {
                new Student()
                {
                    Name = "Hariharan",
                    DateOfBirth = new DateTime(1985, 02, 16),
                    //Id = 1,
                    //Enrolments = new List<Enrolment>()                
                },
                new Student()
                {
                    Name = "Rohit",
                    DateOfBirth = new DateTime(1985, 03, 16),
                    //Id = 2,
                    //Enrolments = new List<Enrolment>()
                },
                new Student()
                {
                    Name = "Rohan",
                    DateOfBirth = new DateTime(1985, 04, 16),
                    //Id = 3,
                    //Enrolments = new List<Enrolment>()
                },
                new Student()
                {
                    Name = "Ravi",
                    DateOfBirth = new DateTime(1985, 05, 16),
                    //Id = 4,
                    //Enrolments = new List<Enrolment>()
                },
            };
            return students;
        }
        
        public static IEnumerable<LectureTheatre> GetLectureTheaters()
        {
            var lectureTheatres = new List<LectureTheatre>()
            {
                new LectureTheatre() {Name = "Theatre1", Capacity = 5},
                new LectureTheatre() {Name = "Theatre2", Capacity = 25},
                new LectureTheatre() {Name = "Theatre3", Capacity = 50},
            };
            return lectureTheatres;
        }

        public static IEnumerable<Subject> GetSubjects()
        {
            var subjects = new List<Subject>()
            {
                new Subject()
                {
                    Code = "SUBJ01",
                    Title = "Subject1",
                    /*
                    Lectures = new List<Lecture>()
                    {
                        new Lecture(){ Name = "Lecture1", DayOfWeek = DayOfWeek.Monday, Duration = 40, StartTime = "9:00 AM", }
                    } 
                    */
                },
                new Subject()
                {
                    Code = "SUBJ02",
                    Title = "Subject2",
                    
                },
                new Subject()
                {
                    Code = "SUBJ03",
                    Title = "Subject3",
                    
                },
                new Subject()
                {
                    Code = "SUBJ04",
                    Title = "Subject4",
                    
                },
                new Subject()
                {
                    Code = "SUBJ05",
                    Title = "Subject5",
                    
                },
            };
            return subjects;
        }
    }
}
