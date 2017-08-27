namespace UniversityManagement.Application.Models
{
    public class EnrolmentModel :ModelBase
    {
        public int StudentModelId { get; set; }
        public StudentModel StudentModel { get; set; }
        public int LectureModelId { get; set; }
        public LectureModel LectureModel { get; set; }
    }
}