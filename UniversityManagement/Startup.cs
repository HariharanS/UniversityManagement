﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using UniversityManagement.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace UniversityManagement.API
{
    public class Startup
    {
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			// ef
			services.AddDbContext<UniversityManagementContext>(opt=> opt.UseInMemoryDatabase());
			// Configure swagger
			services.AddSwaggerGen(x => x.SwaggerDoc("v1", new Info { Title = "University Management API", Version = "v1" }));
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
