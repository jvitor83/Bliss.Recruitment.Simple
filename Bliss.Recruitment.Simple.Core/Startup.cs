using Bliss.Recruitment.Simple.Abstractions.Services;
using Bliss.Recruitment.Simple.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Recruitment.Simple.Core
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IQuestionService, QuestionService>();


            Data.Startup.ConfigureServices(services, configuration);
        }
    }
}