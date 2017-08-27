using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UniversityManagement.Infrastructure.Interfaces;
using UniversityManagement.Domain.Entities;


namespace UniversityManagement.Application
{
    public class StudentWithEnrolmentsSpecification : ISpecification<Student>
    {
        public StudentWithEnrolmentsSpecification(int studentId)
        {
            StudentId = studentId;
            AddInclude(e => e.Enrolments);
        }

        public int StudentId { get; set; }

        public Expression<Func<Student, bool>> Criteria => c => (StudentId != 0 && c.Id == StudentId);
        public List<Expression<Func<Student, object>>> Includes { get; } = new List<Expression<Func<Student, object>>>();
        public void AddInclude(Expression<Func<Student, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}
