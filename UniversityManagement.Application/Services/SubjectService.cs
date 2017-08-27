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
    public class SubjectService : ISubjectService
    {
        private readonly IRepository<Subject> _subjectRepository;
        private readonly IMapper _mapper;
        public SubjectService(IRepository<Subject> subjectRepository,IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        public async Task<SubjectModel> Create(SubjectModel subjectModel)
        {
            var subject = _mapper.Map<Subject>(subjectModel);
            var subjectResult = _subjectRepository.Add(subject);
            var subjectModelResult = _mapper.Map<SubjectModel>(subjectResult);
            return subjectModelResult;
        }

        public async Task<IEnumerable<SubjectModel>> GetAll()
        {
            var subjects = _subjectRepository.GetAll();
            var subjectModels = _mapper.Map<IEnumerable<SubjectModel>>(subjects);
            return subjectModels;
        }

        public async Task<SubjectModel> GetById(int id)
        {
            var subject = _subjectRepository.GetById(id);
            var subjectModel = _mapper.Map<SubjectModel>(subject);
            return subjectModel;
        }
    }
}
