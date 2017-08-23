using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityManagement.Application.Interfaces;
using UniversityManagement.Application.Models;

namespace UniversityManagement.Application.Services
{
    public class StudentService : IStudentService
    {
        public StudentService()
        {
        }

        public Task<StudentModel> Create(StudentModel student)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Enrol the specified studentId and lectureId.
        /// </summary>
        /// <returns>The enrol.</returns>
        /// <param name="studentId">Student identifier.</param>
        /// <param name="lectureId">Lecture identifier.</param>
        public void Enrol(int studentId, int lectureId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<StudentModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<StudentModel> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
