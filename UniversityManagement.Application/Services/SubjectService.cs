using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using UniversityManagement.Application.Interfaces;
using UniversityManagement.Application.Models;
using UniversityManagement.Domain.Entities;
using UniversityManagement.Infrastructure.Interfaces;

namespace UniversityManagement.Application.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IRepository<Subject> _subjectRepository;
        private readonly IRepository<Lecture> _lectureRepository;
        private readonly IRepository<LectureTheatre> _lectureTheatreRepository;
        private readonly IMapper _mapper;
        public SubjectService(IRepository<Subject> subjectRepository,IRepository<Lecture> lectureRepository,IRepository<LectureTheatre> lectureTheatreRepository,IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _lectureRepository = lectureRepository;
            _lectureTheatreRepository = lectureTheatreRepository;
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

        public async Task<LectureModel> CreateLecture(int id, LectureModel lectureModel)
        {
            var subject = _subjectRepository.GetById(id);
            var lectureTheatre = _lectureTheatreRepository.GetById(lectureModel.LectureTheatreModelId);
            var lecture = _mapper.Map<Lecture>(lectureModel);
            lecture.Subject = subject;
            lecture.SubjectId = subject.Id;
            lecture.LectureTheatre = lectureTheatre;
            lecture.LectureTheatreId = lectureTheatre.Id;
            var lectureResult = _lectureRepository.Add(lecture);
            var lectureModelResult = _mapper.Map<LectureModel>(lectureResult);
            return lectureModelResult;
        }
    }
}
