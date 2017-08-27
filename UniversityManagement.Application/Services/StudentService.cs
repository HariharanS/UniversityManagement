using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using UniversityManagement.Application.Interfaces;
using UniversityManagement.Application.Models;
using UniversityManagement.Domain.Entities;
using UniversityManagement.Domain.Interfaces;

namespace UniversityManagement.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IMapper _mapper;
        public StudentService(IRepository<Student> studentRepository,IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<StudentModel> Create(StudentModel studentModel)
        {
            try
            {
				var student = _mapper.Map<Student>(studentModel);
				var studentResult = _studentRepository.Add(student);
				var studentModelResult = _mapper.Map<StudentModel>(studentResult);
				return studentModelResult;
            }
            catch(Exception ex)
            {
                throw;
            }
            //return studentModel;
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

        public async Task<IEnumerable<StudentModel>> GetAll()
        {
            var students = _studentRepository.GetAll();

            var studentModels = _mapper.Map<IEnumerable<StudentModel>>(students);
            return studentModels;
        }

        public Task<StudentModel> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
