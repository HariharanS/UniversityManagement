using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniversityManagement.Application.Interfaces;
using UniversityManagement.Application.Models;
using UniversityManagement.Domain.Entities;
using UniversityManagement.Infrastructure.Interfaces;

namespace UniversityManagement.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Lecture> _lectureRepository;
        private readonly IRepository<Enrolment> _enrolRepository;
        private readonly IMapper _mapper;
        public StudentService(IRepository<Student> studentRepository,IRepository<Lecture> lectureRepository,IRepository<Enrolment> enrolRepository,IMapper mapper)
        {
            _studentRepository = studentRepository;
            _lectureRepository = lectureRepository;
            _enrolRepository = enrolRepository;
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
        

        public async Task<IEnumerable<StudentModel>> GetAll()
        {
            var students = _studentRepository.GetAll();

            var studentModels = _mapper.Map<IEnumerable<StudentModel>>(students);
            return studentModels;
        }

        public async Task<StudentModel> GetById(int id)
        {
            var student = _studentRepository.GetById(id);
            var studentModel = _mapper.Map<StudentModel>(student);
            return studentModel;
        }
    }
}
