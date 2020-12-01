using Bliss.Recruitment.Simple.Api.Documentation;
using Bliss.Recruitment.Simple.Api.HealthCheck;
using Bliss.Recruitment.Simple.Api.Models;
using Bliss.Recruitment.Simple.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bliss.Recruitment.Simple.Api
{
    public class Startup
    {
        private const string DatabaseConnectionStringName = "DefaultConnection";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddSwaggerConfiguration();

            services.AddAutoMapperConfiguration();

            string databaseConnectionString = this.Configuration.GetConnectionString(DatabaseConnectionStringName);

            services.AddHealthCheckConfiguration(databaseConnectionString);

            services.ConfigureServicesForCore(Configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwaggerConfiguration();

            app.UseHealthCheckConfiguration();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
