using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MyCQRSTemplate.Application.Common.Extensions
{
    //This is here because all the mediator handlers are here. 
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationInjections(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}