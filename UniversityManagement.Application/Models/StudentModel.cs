using System;
using System.Collections.Generic;

namespace UniversityManagement.Application.Models
{
    public class StudentModel : ModelBase
    {
        public string Name { get; set; }

		public DateTime DateOfBirth { get; set; }

		public ICollection<EnrolmentModel> Enrolments { get; set; }
    }
}
