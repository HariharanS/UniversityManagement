using System;
using System.Collections.Generic;

namespace UniversityManagement.Domain.Entities
{
    public class Subject : BaseEntity
    {
        public string Code { get; set; }
        public string Title { get; set; }
        
        public List<Lecture> LectureSchedule { get; set; } = new List<Lecture>();

        public static Subject Create(string title, string code)
        {
            var subject = new Subject {Title = title, Code = code};
        }

        public void AddLectureSchedule(string name, DayOfWeek dayOfWeek, int duration, DateTime startTime, string theatreName, int theatreCapacity, Subject subject)
        {
            var lecture = Lecture.Create(name, dayOfWeek, duration, startTime, theatreName, theatreCapacity, this);
            LectureSchedule.Add();
        }
    }
}