using System;
using System.Collections.Generic;

namespace UniversityManagement.Application.Models
{
    public class SubjectModel : ModelBase
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public List<LectureModel> LectureSchedules { get; set; }
    }
}
