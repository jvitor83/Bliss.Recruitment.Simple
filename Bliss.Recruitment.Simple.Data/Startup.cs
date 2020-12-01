using Bliss.Recruitment.Simple.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Bliss.Recruitment.Simple.Data
{
    public static class Startup
    {
        public static void ConfigureServicesForData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IQuestionRepository, QuestionRepository>();

            services.AddDbContext<RecruitmentContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

        }
    }
}
