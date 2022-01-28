using EdenLab.Tests.Integration.Sdk.Extensions;
using Microsoft.Extensions.DependencyInjection;
using TestTask.Creatio.Tests.Integration.Clients.Abstractions;
using TestTask.Creatio.Tests.Integration.Clients.Implementation;

namespace TestTask.Creatio.Tests.Integration.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddClients(this IServiceCollection services)
        {
            services.AddCoreClients();
            services.AddScoped<IBookClient, BookClient>();
            services.AddScoped<IProjectCreatioClient, ProjectCreatioClient>();
        }
    }
}
