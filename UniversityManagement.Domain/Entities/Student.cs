using System;
using System.Collections.Generic;
using System.Linq;

namespace UniversityManagement.Domain.Entities
{
    public class Student : BaseEntity
    {
        public const int MaxLectureTimePerWeek = 10 * 60;
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

        public IEnumerable<IGrouping<int, LectureTimeWeek>> LectureTimePerWeek()
        {
            var lectureTimeWeeks = Enrolments
                .Select(s => new LectureTimeWeek() {Duration = s.Lecture.Duration, Week = s.WeekOfYear}).ToList();
            
            var lectureTimePerWeeks = lectureTimeWeeks.GroupBy(w => w.Week);
            return lectureTimePerWeeks;
        }
        
        

        
    }
}