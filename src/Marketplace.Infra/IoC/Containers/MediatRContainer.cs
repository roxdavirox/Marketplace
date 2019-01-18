using Marketplace.Shared;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Marketplace.Infra.IoC.Containers
{
    public static class MediatRContainer
    { 
        public static void AddMediatRDependencyHandlers(this IServiceCollection services)
        {
            var assemblyApp = AppDomain.CurrentDomain.Load(Settings.MediatRAssemblyName);
            services.AddMediatR();
        }
    }
}
