using System;
using System.Threading.Tasks;
using UniversityManagement.Application.Models;

namespace UniversityManagement.Application.Interfaces
{
    public interface ISubjectService : IBaseService<SubjectModel>
    {
        Task<LectureModel> CreateLecture(int id, LectureModel lectureModel);
    }
}
