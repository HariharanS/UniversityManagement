using System;
using System.Collections.Generic;

namespace UniversityManagement.Domain.Entities
{
    public class Subject : BaseEntity
    {
        public string Code { get; set; }
        public string Title { get; set; }
        
        public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();

        public static Subject Create(string title, string code)
        {
            var subject = new Subject {Title = title, Code = code};
            return subject;
        }

        public void AddLectureSchedule(string name, DayOfWeek dayOfWeek, int duration, string startTime, LectureTheatre lectureTheatre)
        {
            var lecture = Lecture.Create(this,lectureTheatre,name, dayOfWeek, startTime, duration);
            Lectures.Add(lecture);
        }
    }
}