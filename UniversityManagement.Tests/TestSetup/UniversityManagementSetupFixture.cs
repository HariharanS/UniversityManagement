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
    public class UniversityManagementSetupFixture : IDisposable
    {
		private readonly TestServer _server;
		private readonly HttpClient _client;
		private readonly UniversityManagementContext _dbContext;
        private const string Environment = "Development";
        public UniversityManagementSetupFixture()
        {
			var webHostBuilder = new WebHostBuilder().UseStartup<Startup>().UseEnvironment(Environment);
			//var serviceCollection = new ServiceCollection();
			//serviceCollection.AddDbContext<UniversityManagementContext>(x => x.UseInMemoryDatabase("University"));
			webHostBuilder.ConfigureServices(collection => collection.AddDbContext<UniversityManagementContext>(x => x.UseInMemoryDatabase("University")));

			_server = new TestServer(webHostBuilder);
			_client = _server.CreateClient();

			_dbContext = _server.Host.Services.GetService<UniversityManagementContext>();
            SetUpData();

        }

        public HttpClient TestHttpClient 
        { 
            get 
            { 
                return _client;
            }
        }

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
