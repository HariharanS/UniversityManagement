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
        public void CreateStudentsTest()
        {
            var studentModel = new StudentModel { Name = "Hariharan" };
            var content = SerialiseObjectToJson(studentModel);
            var response = _client.PostAsync(StudentRequest, content);
            var result = response.Result;
            result.EnsureSuccessStatusCode();

            var studentModelResult = JsonConvert.DeserializeObject<StudentModel>(response.Result.Content.ReadAsStringAsync().Result);
            Assert.NotEqual(0, studentModelResult.Id);
            // ensure that new student entity is added to db
            var studentsResult = GetStudents();
            Assert.Equal(5, studentsResult.Count());
            _testOutputHelper.WriteLine("Success");

        }

        static StringContent SerialiseObjectToJson(object studentModel)
        {
            var serialisedStudentModel = JsonConvert.SerializeObject(studentModel);
            var content = new StringContent(serialisedStudentModel, Encoding.Unicode, "application/json");
            return content;
        }
    }
}
