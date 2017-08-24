using System;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Xunit;
using Xunit.Abstractions;
using UniversityManagement.API;
using UniversityManagement.Application.Models;
using Newtonsoft.Json;
using System.Text;

namespace UniversityManagement.Tests
{
    public class UniversityManagementTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly TestServer _server;
        private readonly HttpClient _client;
        private const string Environment = "Development";
        public UniversityManagementTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>().UseEnvironment(Environment));
            _client = _server.CreateClient();
        }

        ~UniversityManagementTests()
        {
            _client.Dispose();
            _server.Dispose();
        }

        [Fact]
        public void GetStudentsTest()
        {
            const string request = "/api/student";

            var response =  _client.GetAsync(request);
            var result = response.Result;
            result.EnsureSuccessStatusCode();
            _testOutputHelper.WriteLine(response.Result.Content.ReadAsStringAsync().Result.ToString());

        }

		[Fact]
		public void CreateStudentsTest()
		{
			const string request = "/api/student";
            var studentModel = new StudentModel { Name = "Hariharan" };
            var serialisedStudentModel = JsonConvert.SerializeObject(studentModel);
            var content = new StringContent(serialisedStudentModel, Encoding.Unicode, "application/json");
            var response = _client.PostAsync(request,content);
			var result = response.Result;
			result.EnsureSuccessStatusCode();
			_testOutputHelper.WriteLine(response.Result.Content.ReadAsStringAsync().Result.ToString());

		}
    }
}
