using System;

namespace UniversityManagement.Domain.Entities
{
    public class Lecture : BaseEntity
    {
        public string Name { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public DateTime StartTime { get; set; }
        // in mins
        public int Duration { get; set; }
        public LectureTheatre LectureTheatre { get; set; }
        public virtual Subject Subject { get; set; }

        public static Lecture Create(string name, DayOfWeek dayOfWeek, int duration, DateTime startTime, string theatreName, int theatreCapacity, Subject subject)
        {
            var lecture = new Lecture
            {
                Name = name, 
                DayOfWeek = dayOfWeek,
                Duration = duration, 
                StartTime = startTime, 
                LectureTheatre = new LectureTheatre
                {
                    Name = theatreName,
                    Capacity = theatreCapacity
                },
                Subject = subject,
            };

            return lecture;
        }
    }
}