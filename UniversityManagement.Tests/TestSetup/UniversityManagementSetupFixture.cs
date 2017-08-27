using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using UniversityManagement.API;
using UniversityManagement.Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using UniversityManagement.Tests.TestData;

namespace UniversityManagement.Tests
{
	/// <summary>
	/// Test setup
	/// 1. In memory Test server - for integration tests
	/// 2. In memory Db - University - instead of using a database
	/// 3. Client - get the http client from server
	/// 4. Setup test data
	/// </summary>
    public class UniversityManagementSetupFixture : IDisposable
    {
		private readonly TestServer _server;
		private readonly HttpClient _client;
		private readonly UniversityManagementContext _dbContext;
        private const string Environment = "Development";
        public UniversityManagementSetupFixture()
        {
	        // web host builder
			var webHostBuilder = new WebHostBuilder().UseStartup<Startup>().UseEnvironment(Environment);
			webHostBuilder.ConfigureServices(collection => collection.AddDbContext<UniversityManagementContext>(x => x.UseInMemoryDatabase("University")));
			// create server using web host builder
			_server = new TestServer(webHostBuilder);
	        // get rest client
			_client = _server.CreateClient();
			
	        // get ef context used in server
			_dbContext = _server.Host.Services.GetService<UniversityManagementContext>();
	        
	        // setup initial test data
            SetUpData();

        }

        public HttpClient TestHttpClient => _client;

	    private void SetUpData()
		{
			var testData = new UniversityManagementTestData(_dbContext);
			testData.AddStudentsToDb();
			testData.AddLectureTheatresToDb();
			testData.AddSubjectsToDb();
		}

        public void Dispose()
        {
			_client.Dispose();
			_server.Dispose();
        }
    }
}
