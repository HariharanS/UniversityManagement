namespace UniversityManagement.Domain.Entities
{
    public class Enrolment : BaseEntity
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int LectureId { get; set; }
        public Lecture Lecture { get; set; }

        public Enrolment Create(Lecture lecture, Student student)
        {
            var enrolment = new Enrolment
            {
                Lecture = lecture,
                Student = Student
            };
            return enrolment;
        }
    }
}