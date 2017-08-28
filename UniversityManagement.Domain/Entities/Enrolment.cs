using System;
using UniversityManagement.Domain.Helpers;

namespace UniversityManagement.Domain.Entities
{
    public class Enrolment : BaseEntity
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int LectureId { get; set; }
        public Lecture Lecture { get; set; }

        public DateTime EnroledDate { get; set; }

        public int WeekOfYear => EnroledDate.GetWeekOfYear();

        public Enrolment Create(Lecture lecture, Student student,DateTime enroledDate)
        {
            var enrolment = new Enrolment
            {
                Lecture = lecture,
                Student = Student,
                EnroledDate = enroledDate
            };
            return enrolment;
        }
    }

    public class LectureTimeWeek
    {
        public int Duration { get; set; }
        public int Week { get; set; }
    }
}