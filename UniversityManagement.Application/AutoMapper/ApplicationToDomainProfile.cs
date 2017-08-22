using AutoMapper;
using UniversityManagement.Application.Models;
using UniversityManagement.Domain.Entities;

namespace UniversityManagement.Application.AutoMapper
{
    public class ApplicationToDomainProfile : Profile
    {
        public ApplicationToDomainProfile()
        {
            CreateMap<LectureTheatreModel, LectureTheatre>().ReverseMap();
            CreateMap<LectureScheduleModel, Lecture>().ReverseMap();
            CreateMap<SubjectModel, Subject>().ReverseMap();
        }
    }
}