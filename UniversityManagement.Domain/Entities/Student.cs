using System;
using System.Collections.Generic;

namespace UniversityManagement.Domain.Entities
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<Enrolment> Enrolments { get; set; }

        public static Student Create(string name, DateTime dateOfBirth)
        {
            var student = new Student
            {
                Name = name,
                DateOfBirth = dateOfBirth,
            };
            return student;
        }

        public void Enroll(Lecture lecture)
        {
            //lecture.e
        }
    }
}