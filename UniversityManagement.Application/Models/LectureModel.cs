using System;

namespace UniversityManagement.Application.Models
{
    public class LectureModel :ModelBase
    {
        public string Name { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int Duration { get; set; }
        public string StartTime { get; set; }
        public LectureTheatreModel LectureTheatreModel { get; set; }
        public int LectureTheatreModelId { get; set; }
        public SubjectModel SubjectModel { get; set; }
        public int SubjectModelId { get; set; }
    }
}