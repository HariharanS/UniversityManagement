using System;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Xunit;
using Xunit.Abstractions;
using UniversityManagement.API;

namespace UniversityManagement.Tests
{
    public class UniversityManagementTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public UniversityManagementTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>().UseEnvironment("Development"));
            _client = _server.CreateClient();
        }

        ~UniversityManagementTests()
        {
            _client.Dispose();
            _server.Dispose();
        }

        [Fact]
        public void IntegrationTest1()
        {
            var request = "/api/student";

            var response =  _client.GetAsync(request);
            var result = response.Result;
            result.EnsureSuccessStatusCode();
            _testOutputHelper.WriteLine(response.Result.Content.ReadAsStringAsync().Result.ToString());

        }
    }
}
