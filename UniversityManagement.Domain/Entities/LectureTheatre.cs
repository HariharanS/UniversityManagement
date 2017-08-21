namespace UniversityManagement.Domain.Entities
{
    public class LectureTheatre : BaseEntity
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public virtual Lecture Lecture { get; set; }
    }
}