using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityManagement.Application.Interfaces;
using UniversityManagement.Application.Models;

namespace UniversityManagement.Application.Services
{
    public class SubjectService : ISubjectService
    {
        public SubjectService()
        {
        }

        public Task<SubjectModel> Create(SubjectModel student)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SubjectModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SubjectModel> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
