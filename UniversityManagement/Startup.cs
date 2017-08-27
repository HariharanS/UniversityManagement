using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using UniversityManagement.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using UniversityManagement.Application.AutoMapper;
using UniversityManagement.Application.Interfaces;
using UniversityManagement.Application.Services;
using UniversityManagement.Domain.Interfaces;

namespace UniversityManagement.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
		{
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
                .AddEnvironmentVariables();

            Configuration = configurationBuilder.Build();

		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			
			// ef
			if(EnvironmentName.Development != "Development")
            	services.AddDbContext<UniversityManagementContext>(x=> x.UseInMemoryDatabase("University"));
			// Configure swagger
			services.AddSwaggerGen(x => x.SwaggerDoc("v1", new Info { Title = "University Management API", Version = "v1" }));
            // configure services
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<ILectureTheatreService,LectureTheatreService>();

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
			
			// configure automapper

			var mapperConfiguration = new AutoMapperConfiuguration();
			var mapper = mapperConfiguration.CreateMapper();
			services.AddSingleton(mapper);
			
			
            services
                .AddMvc()
                .AddJsonOptions(options => 
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;
                });
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			// log to console
            loggerFactory.AddConsole();
			app.UseMvc();
			
			// use ef core
			// use swagger
			app.UseSwagger();
			app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "University Management API v1"));
		}
    }
}
