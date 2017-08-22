namespace UniversityManagement.Domain.Entities
{
    public class LectureTheatre : BaseEntity
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        // Lecture - parent entity
        public int LectureId { get; set; }
        public Lecture Lecture { get; set; }

        public LectureTheatre Create(string name,int capacity)
        {
            var lectureTheatre = new LectureTheatre
            {
                Name = name,
                Capacity = capacity
            };
            return lectureTheatre;
        }
    }
}