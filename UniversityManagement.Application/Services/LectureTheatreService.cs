using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityManagement.Application.Interfaces;
using UniversityManagement.Application.Models;

namespace UniversityManagement.Application.Services
{
    public class LectureTheatreService : ILectureTheatreService
    {
        public LectureTheatreService()
        {
        }

        public Task<LectureTheatreModel> Create(LectureTheatreModel student)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LectureTheatreModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<LectureTheatreModel> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
