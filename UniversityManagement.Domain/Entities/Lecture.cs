using System;
using System.Security.Cryptography;

namespace UniversityManagement.Domain.Entities
{
    public class Lecture : BaseEntity
    {
        public string Name { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public string StartTime { get; set; }
        // in mins
        public int Duration { get; set; }

        // lecture theatre - child
        public int LectureTheatreId { get; set; }
        public LectureTheatre LectureTheatre { get; set; }
        // subject - parent entity
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public static Lecture Create(Subject subject,LectureTheatre lectureTheatre,string name, DayOfWeek dayOfWeek, string startTime, int duration)
        {
            var lecture = new Lecture
            {
                Name = name, 
                DayOfWeek = dayOfWeek,
                Duration = duration, 
                StartTime = startTime,
                LectureTheatre = lectureTheatre,
                SubjectId = subject.Id,
            };

            return lecture;
        }
    }
}