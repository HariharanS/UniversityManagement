using AutoMapper;
using UniversityManagement.Application.Models;
using UniversityManagement.Domain.Entities;

namespace UniversityManagement.Application.AutoMapper
{
    public class ApplicationToDomainProfile : Profile
    {
        public ApplicationToDomainProfile()
        {
            CreateMap<LectureTheatreModel, LectureTheatre>()
                .ReverseMap();
            CreateMap<LectureModel, Lecture>()
                .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.SubjectModel))
                .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.SubjectModelId))
                .ForMember(dest => dest.LectureTheatre, opt => opt.MapFrom(src => src.LectureTheatreModel))
                .ForMember(dest => dest.LectureTheatreId, opt => opt.MapFrom(src => src.LectureTheatreModelId))
                .ReverseMap();
            CreateMap<SubjectModel, Subject>()
                .ForMember(dest => dest.Lectures, opt=> opt.MapFrom(src => src.LectureSchedules))
                .ReverseMap();
            CreateMap<EnrolmentModel, Enrolment>()
				.ReverseMap();
            CreateMap<StudentModel,Student>()
                .ForMember(dest => dest.Enrolments, opt => opt.MapFrom(src => src.Enrolments))
                .ReverseMap();
        }
    }
}