using AutoMapper;
using Bliss.Recruitment.Simple.Abstractions.Services;
using Bliss.Recruitment.Simple.Core.Email;
using Bliss.Recruitment.Simple.Core.Services;
using Bliss.Recruitment.Simple.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;

namespace Bliss.Recruitment.Simple.Core
{
    public static class Startup
    {
        public static void ConfigureServicesForCore(this IServiceCollection services, IConfiguration configuration)
        {
            Assembly assembly = typeof(Startup).Assembly;

            services.AddAutoMapper(assembly);

            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IShareService, ShareService>();

            services.AddValidatorsFromAssembly(assembly);

            var notificationMetadata = configuration.GetSection("NotificationMetadata").Get<NotificationMetadata>();
            if (notificationMetadata != null)
            {
                services.AddSingleton(notificationMetadata);
            }


            services.ConfigureServicesForData(configuration);
        }
    }
}