using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using UniversityManagement.Application.Interfaces;
using UniversityManagement.Application.Models;
using UniversityManagement.Domain.Entities;
using UniversityManagement.Infrastructure.Interfaces;

namespace UniversityManagement.Application.Services
{
    public class LectureTheatreService : ILectureTheatreService
    {
        private readonly IRepository<LectureTheatre> _lectureTheatreRepository;
        private readonly IMapper _mapper;
        public LectureTheatreService(IRepository<LectureTheatre> lectureTheatreRepository,IMapper mapper)
        {
            _lectureTheatreRepository = lectureTheatreRepository;
            _mapper = mapper;
        }

        public async Task<LectureTheatreModel> Create(LectureTheatreModel lectureTheatreModel)
        {
            var lectureTheature = _mapper.Map<LectureTheatre>(lectureTheatreModel);
            var lectureTheatreResult = _lectureTheatreRepository.Add(lectureTheature);
            var lectureTheatreModelResult = _mapper.Map<LectureTheatreModel>(lectureTheatreResult);

            return lectureTheatreModelResult;
        }

        public async Task<IEnumerable<LectureTheatreModel>> GetAll()
        {
            var lectureTheatres = _lectureTheatreRepository.GetAll();
            var lectureTheatreModels = _mapper.Map<IEnumerable<LectureTheatreModel>>(lectureTheatres);
            return lectureTheatreModels;
        }

        public async Task<LectureTheatreModel> GetById(int id)
        {
            var lectureTheatre = _lectureTheatreRepository.GetById(id);
            var lectureTheatreModel = _mapper.Map<LectureTheatreModel>(lectureTheatre);
            return lectureTheatreModel;
        }
    }
}
