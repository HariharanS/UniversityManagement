using System;

namespace UniversityManagement.Application.Models
{
    public class LectureScheduleModel :ModelBase
    {
        public string Name { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int Duration { get; set; }
        public DateTime StartTime { get; set; }
        public LectureTheatreModel LectureTheatreModel { get; set; }
    }
}