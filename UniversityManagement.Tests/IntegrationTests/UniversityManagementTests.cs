using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Xunit;
using Xunit.Abstractions;
using UniversityManagement.API;
using UniversityManagement.Application.Models;
using Newtonsoft.Json;
using System.Text;
using Microsoft.EntityFrameworkCore;
using UniversityManagement.Tests.TestData;
using UniversityManagement.Infrastructure.Database;

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
            
            var response = _client.GetAsync(studentRequest);
            var result = response.Result;
            result.EnsureSuccessStatusCode();
            var studentsResult =
                JsonConvert.DeserializeObject<IEnumerable<StudentModel>>(response.Result.Content.ReadAsStringAsync().Result);
            Assert.Equal(4, studentsResult.Count());
            _testOutputHelper.WriteLine("Success");
        }



        [Fact]
		public void CreateStudentsTest()
		{
			var studentModel = new StudentModel { Name = "Hariharan" };
            var serialisedStudentModel = JsonConvert.SerializeObject(studentModel);
            var content = new StringContent(serialisedStudentModel, Encoding.Unicode, "application/json");
            var response = _client.PostAsync(studentRequest,content);
			var result = response.Result;
			result.EnsureSuccessStatusCode();

			var studentModelResult = JsonConvert.DeserializeObject<StudentModel>(response.Result.Content.ReadAsStringAsync().Result);
			Assert.NotEqual(0,studentModelResult.Id);
			_testOutputHelper.WriteLine("Success");

		}
    }
}
