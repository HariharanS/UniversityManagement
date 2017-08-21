using AutoMapper;
using UniversityManagement.Application.Models;
using UniversityManagement.Domain.Entities;

namespace UniversityManagement.Application.AutoMapper
{
    public class ApplicationToDomain : Profile
    {
        public ApplicationToDomain()
        {
            CreateMap<SubjectModel, Student>().;
        }
    }
}