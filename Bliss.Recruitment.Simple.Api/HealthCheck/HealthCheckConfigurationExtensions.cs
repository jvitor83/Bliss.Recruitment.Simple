using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Bliss.Recruitment.Simple.Api.HealthCheck
{
    public static class HealthCheckConfigurationExtensions
    {
        public static IServiceCollection AddHealthCheckConfiguration(this IServiceCollection services, string databaseConnectionString)
        {
            services.AddHealthChecks()
                .AddSqlServer(connectionString: databaseConnectionString,
                name: "sqlserver",
                failureStatus: HealthStatus.Unhealthy,
                timeout: TimeSpan.FromSeconds(5));


            return services;
        }

        public static IApplicationBuilder UseHealthCheckConfiguration(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/health",
               new HealthCheckOptions
               {
                   ResponseWriter = async (context, report) =>
                   {
                       var result = System.Text.Json.JsonSerializer.Serialize(
                           new
                           {
                               status = HelthCheckStatusToString(report.Status),
                           });
                       context.Response.ContentType = MediaTypeNames.Application.Json;
                       await context.Response.WriteAsync(result);
                   }
               });


            return app;
        }

        private static string HelthCheckStatusToString(HealthStatus status)
        {
            switch (status)
            {
                case HealthStatus.Unhealthy:
                    return "Service Unavailable. Please try again later.";
                    break;
                case HealthStatus.Degraded:
                    return "Service unstable, proceed with caution.";
                    break;
                case HealthStatus.Healthy:
                    return "OK";
                    break;
                default:
                    return "Unknown";
                    break;
            }
        }


    }
}
