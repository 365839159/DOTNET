using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Application.Commands.Sample;
using Sample.Application.Queries.Sample;
using Sample.Application.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application
{
    public static class ApplicationServiceRegister
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            AddValidatorServices(services);
            AddBusinessService(services);
            return services;
        }

        private static void AddValidatorServices(IServiceCollection services)
        {
            services.AddTransient<IValidator<SampleCommand>, SampleCommandValidation>();
        }

        private static void AddBusinessService(IServiceCollection services)
        {
            services.AddTransient<ISampleQueries, SampleQueries>();
        }
    }
}
