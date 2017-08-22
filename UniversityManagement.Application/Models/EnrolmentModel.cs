namespace UniversityManagement.Application.Models
{
    public class EnrolmentModel :ModelBase
    {
        public StudentModel StudentModel { get; set; }
        public LectureScheduleModel LectureScheduleModel { get; set; }
    }
}