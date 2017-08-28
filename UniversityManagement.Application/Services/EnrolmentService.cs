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
    public class EnrolmentService : IEnrolmentService
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Lecture> _lectureRepository;
        private readonly IRepository<Enrolment> _enrolRepository;
        private readonly IMapper _mapper;
        public EnrolmentService(IRepository<Student> studentRepository,IRepository<Lecture> lectureRepository,IRepository<Enrolment> enrolRepository,IMapper mapper)
        {
            _studentRepository = studentRepository;
            _lectureRepository = lectureRepository;
            _enrolRepository = enrolRepository;
            _mapper = mapper;
        }

        public async Task<EnrolmentModel> GetById(int id)
        {
            var enrolment = _studentRepository.GetById(id);
            var enrolmentModel = _mapper.Map<EnrolmentModel>(enrolment);
            return enrolmentModel;
        }

        public async Task<IEnumerable<EnrolmentModel>> GetAll()
        {
            var enrolments = _studentRepository.GetAll();
            var enrolmentModels = _mapper.Map<IEnumerable<EnrolmentModel>>(enrolments);
            return enrolmentModels;
        }

        public async Task<EnrolmentModel> Create(EnrolmentModel enrolmentModel)
        {
            // queries
            var studentQuery = _studentRepository.Get();
            var lectureQuery = _lectureRepository.Get();
            var enrolmentQuery = _enrolRepository.Get();
            // get enrolment object
            var enrolment = _mapper.Map<Enrolment>(enrolmentModel);
            
            // object graphs
            var studentGraph = studentQuery
                .Where(w => w.Id == enrolmentModel.StudentModelId)
                .Include(e => e.Enrolments)
                .ThenInclude(l => l.Lecture)
                .ThenInclude(t => t.LectureTheatre).FirstOrDefault();
            
            var lecture = lectureQuery
                .Where(w => w.Id == enrolmentModel.LectureModelId)
                .Include(i => i.LectureTheatre).FirstOrDefault();
            
            // enrolment count
            var enrolmentCount = enrolmentQuery.Count(w => w.LectureId == enrolmentModel.LectureModelId);
            // theatre capacity
            var lectureTheatreCapacity = lecture.LectureTheatre.Capacity;
            // throw error if capacity is full
            if(enrolmentCount == lectureTheatreCapacity)
                throw new Exception("Enrolment is unsuccessful. Lecture hall is full.");
            // get the week of year for the current enrolment
            var requestedLectureWeek = enrolment.WeekOfYear;
            // get the duration for the request lecture
            var requestedLectureDuration = lecture.Duration;
            LectureTimeWeek currentRequestedLectureTimeWeek = null;
            if (studentGraph.Enrolments.Any())
            {
                // get the a weekly lecture time for the student
                var currentLectureTimePerWeeks = studentGraph.LectureTimePerWeek();
                // get the lecturetime for the requested lecture week
                currentRequestedLectureTimeWeek = currentLectureTimePerWeeks.FirstOrDefault(x => x.Key == requestedLectureWeek).FirstOrDefault();
            }
            // calculate the new duration for the week
            var newDuration = requestedLectureDuration + (currentRequestedLectureTimeWeek?.Duration ?? 0);
            // check if it exceeds the max lecturetimr a student can enrol for in a week, then theow error
            if (newDuration > Student.MaxLectureTimePerWeek)
            {
                throw new Exception("Enrolment is unsuccessful. Student has exceed the maximum hours per week.");
            }
            var enrolmentResult = _enrolRepository.Add(enrolment);
            var enrolmentModelResult = _mapper.Map<EnrolmentModel>(enrolmentResult);

            return enrolmentModelResult;
        }
    }
}
