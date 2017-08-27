using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UniversityManagement.Domain.Entities;
using UniversityManagement.Infrastructure.Interfaces;

namespace UniversityManagement.Application
{
    public class EnrolmentWithLectureSpecification : ISpecification<Enrolment>
    {
        public EnrolmentWithLectureSpecification()
        {
            
        }
        public Expression<Func<Enrolment, bool>> Criteria { get; }
        public List<Expression<Func<Enrolment, object>>> Includes { get; }
        public void AddInclude(Expression<Func<Enrolment, object>> includeExpression)
        {
            throw new NotImplementedException();
        }
    }
}