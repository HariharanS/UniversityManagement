using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Xunit;
using Xunit.Abstractions;
using UniversityManagement.Application.Models;
using Newtonsoft.Json;
using System.Text;

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

        #region Students Tests

        [Fact]
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

        [Fact]
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

        [Fact]
        public void GetSubjectsTest()
        {
            var subjects = GetSubjects();
            Assert.Equal(5,subjects.Count());
        }

        [Fact]
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

        IEnumerable<SubjectModel> GetSubjects()
        {
            var response = _client.GetAsync(SubjectRequest);
            var result = response.Result;
            result.EnsureSuccessStatusCode();
            var subjectsResult = JsonConvert.DeserializeObject<IEnumerable<SubjectModel>>(response.Result.Content.ReadAsStringAsync().Result);
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
