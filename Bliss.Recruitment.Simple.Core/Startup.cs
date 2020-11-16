using Bliss.Recruitment.Simple.Abstractions.Services;
using Bliss.Recruitment.Simple.Core.Email;
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
            services.AddScoped<IShareService, ShareService>();

            var notificationMetadata = configuration.GetSection("NotificationMetadata").Get<NotificationMetadata>();
            services.AddSingleton(notificationMetadata);


            Data.Startup.ConfigureServices(services, configuration);
        }
    }
}