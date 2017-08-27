using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Xunit;
using Xunit.Abstractions;
using UniversityManagement.Application.Models;
using Newtonsoft.Json;
using System.Text;
using UniversityManagement.Tests.TestHelpers;

namespace UniversityManagement.Tests
{
    public class UniversityManagementTests : IClassFixture<UniversityManagementSetupFixture>
    {
        readonly ITestOutputHelper _testOutputHelper;
        readonly UniversityManagementSetupFixture _setupFixture;
        readonly HttpClient _client;
        private const string StudentRequest = "/api/student";
        private const string LectureTheatreRequest = "/api/lecturetheatre";
        private const string SubjectRequest = "/api/subject";
        public UniversityManagementTests(ITestOutputHelper testOutputHelper, UniversityManagementSetupFixture setupFixture)
        {
            _testOutputHelper = testOutputHelper;
            _setupFixture = setupFixture;
            _client = setupFixture.TestHttpClient;
        }

        #region LectureTheatre Tests

        [Fact,TestPriority(1)]
        public void GetLectureTheatresTest()
        {
            var lectureTheatres = GetLectureTheatres();
            Assert.Equal(3,lectureTheatres.Count());
        }
        
        [Fact,TestPriority(2)]
        public void CreateLectureTheareTest()
        {
            var lectureTheatreModel = new LectureTheatreModel() {Name = "Theatre4", Capacity = 5};
            var content = SerialiseObjectToJson(lectureTheatreModel);
            var response = _client.PostAsync(LectureTheatreRequest, content);
            var result = response.Result;
            result.EnsureSuccessStatusCode();
            var lectureTheatreModelResult =
                JsonConvert.DeserializeObject<LectureTheatreModel>(result.Content.ReadAsStringAsync().Result);
            
            Assert.NotEqual(0,lectureTheatreModelResult.Id);

            var lectureTheatreModels = GetLectureTheatres();
            Assert.Equal(4,lectureTheatreModels.Count());
        }
        
        IEnumerable<LectureTheatreModel> GetLectureTheatres()
        {
            var response = _client.GetAsync(LectureTheatreRequest);
            var result = response.Result;
            result.EnsureSuccessStatusCode();
            var lectureTheatresResult =
                JsonConvert.DeserializeObject<IEnumerable<LectureTheatreModel>>(result.Content.ReadAsStringAsync()
                    .Result);
            return lectureTheatresResult;
        }
        
        

        #endregion
        
        #region Students Tests

        [Fact,TestPriority(5)]
        public void GetStudentsTest()
        {
            var studentsResult = GetStudents();
            Assert.Equal(4, studentsResult.Count());
            _testOutputHelper.WriteLine("Success");
        }

        IEnumerable<StudentModel> GetStudents()
        {
            var response = _client.GetAsync(StudentRequest);
            var result = response.Result;
            result.EnsureSuccessStatusCode();
            var studentsResult =
                JsonConvert.DeserializeObject<IEnumerable<StudentModel>>(response.Result.Content.ReadAsStringAsync().Result);
            return studentsResult;
        }

        [Fact,TestPriority(6)]
        public void CreateStudentTest()
        {
            var studentModel = new StudentModel { Name = "Hariharan" };
            var content = SerialiseObjectToJson(studentModel);
            var response = _client.PostAsync(StudentRequest, content);
            var result = response.Result;
            result.EnsureSuccessStatusCode();

            var studentModelResult = JsonConvert.DeserializeObject<StudentModel>(result.Content.ReadAsStringAsync().Result);
            Assert.NotEqual(0, studentModelResult.Id);
            // ensure that new student entity is added to db
            var studentsResult = GetStudents();
            Assert.Equal(5, studentsResult.Count());
            _testOutputHelper.WriteLine("Success");

        }

        #endregion
        
        #region Subjects Tests

        [Fact,TestPriority(3)]
        public void GetSubjectsTest()
        {
            var subjects = GetSubjects();
            Assert.Equal(5,subjects.Count());
        }

        [Fact,TestPriority(4)]
        public void CreateSubjectTest()
        {
            var subjectModel = new SubjectModel() { Code = "SUBJ6", Title = "Subject6" };
            var content = SerialiseObjectToJson(subjectModel);
            var response = _client.PostAsync(SubjectRequest, content);
            var result = response.Result;
            result.EnsureSuccessStatusCode();

            var subjectModelResult = JsonConvert.DeserializeObject<SubjectModel>(result.Content.ReadAsStringAsync().Result);

            Assert.NotEqual(0,subjectModelResult.Id);
            var subjectsResult = GetSubjects();
            Assert.Equal(6,subjectsResult.Count());
        }

        [Fact]
        public void CreateLectureTests()
        {
            var subjectId = 1;
            var request = $"{SubjectRequest}/{subjectId}";
            var lectureModel = CreateLectureTestData("Lecture 1", 45, DayOfWeek.Monday, "09:00 AM", 1);

            var content = SerialiseObjectToJson(lectureModel);

            var response = _client.PostAsync(request, content);
            var result = response.Result;
            result.EnsureSuccessStatusCode();
            
            var lectureModelResult  = JsonConvert.DeserializeObject<LectureModel>(result.Content.ReadAsStringAsync().Result);
            
            Assert.NotEqual(0,lectureModelResult.Id);
            Assert.NotNull(lectureModelResult.SubjectModel);
            Assert.NotNull(lectureModelResult.LectureTheatreModel);
            /*
            
            var lectureModelList = new List<LectureModel>
            {
                CreateLectureTestData("Lecture 1", 45, DayOfWeek.Monday, "09:00 AM", 1),
                CreateLectureTestData("Lecture 2", 45, DayOfWeek.Tuesday, "10:00 AM", 1),
                CreateLectureTestData("Lecture 3", 45, DayOfWeek.Wednesday, "11:00 AM", 1),
                CreateLectureTestData("Lecture 4", 45, DayOfWeek.Thursday, "01:00 PM", 1),
                CreateLectureTestData("Lecture 5", 45, DayOfWeek.Friday, "03:00 PM", 1)
            };
            
            
            lectureModelList.ForEach(lectureModel =>
            {
                
            }); 
            
            */
        }

        public LectureModel CreateLectureTestData(string name,int duration,DayOfWeek dayOfWeek,string startTime,int lectureTheatreModelId)
        {
            var lecture = new LectureModel()
            {
                Name = name,
                Duration = duration,
                DayOfWeek = dayOfWeek,
                StartTime = startTime,
                LectureTheatreModelId = lectureTheatreModelId
            };

            return lecture;
        }
        
        IEnumerable<SubjectModel> GetSubjects()
        {
            var response = _client.GetAsync(SubjectRequest);
            var result = response.Result;
            result.EnsureSuccessStatusCode();
            var subjectsResult = JsonConvert.DeserializeObject<IEnumerable<SubjectModel>>(result.Content.ReadAsStringAsync().Result);
            return subjectsResult;
        }

        #endregion
        
        #region Common

        private static StringContent SerialiseObjectToJson(object model)
        {
            var serialisedModel = JsonConvert.SerializeObject(model);
            var content = new StringContent(serialisedModel, Encoding.Unicode, "application/json");
            return content;
        }

        #endregion
        
    }
}
