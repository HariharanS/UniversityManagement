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
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly UniversityManagementSetupFixture _setupFixture;
        private readonly HttpClient _client;
        private const string studentRequest = "/api/student";
        public UniversityManagementTests(ITestOutputHelper testOutputHelper,UniversityManagementSetupFixture setupFixture)
        {
            _testOutputHelper = testOutputHelper;
            _setupFixture = setupFixture;
            _client = setupFixture.TestHttpClient;
        }

        ~UniversityManagementTests()
        {
            
        }
	    

        [Fact]
        public void GetStudentsTest()
        {
            IEnumerable<StudentModel> studentsResult = GetStudents();
            Assert.Equal(4, studentsResult.Count());
            _testOutputHelper.WriteLine("Success");
        }

        private IEnumerable<StudentModel> GetStudents()
        {
            var response = _client.GetAsync(studentRequest);
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
            var response = _client.PostAsync(studentRequest, content);
            var result = response.Result;
            result.EnsureSuccessStatusCode();

            var studentModelResult = JsonConvert.DeserializeObject<StudentModel>(response.Result.Content.ReadAsStringAsync().Result);
            Assert.NotEqual(0, studentModelResult.Id);
            // ensure that new student entity is added to db
            var studentsResult = GetStudents();
            Assert.Equal(5, studentsResult.Count());
            _testOutputHelper.WriteLine("Success");

        }

        private static StringContent SerialiseObjectToJson(object studentModel)
        {
            var serialisedStudentModel = JsonConvert.SerializeObject(studentModel);
            var content = new StringContent(serialisedStudentModel, Encoding.Unicode, "application/json");
            return content;
        }
    }
}
