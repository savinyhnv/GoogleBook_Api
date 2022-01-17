using EdenLab.FluentApi.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestTask.Creatio.Core.Abstractions.Integration;
using TestTask.Creatio.Integration;
using TestTask.Creatio.Integration.GoogleBooksCLient;

namespace TestTask.Creatio.Extensions.DependencyInjection
{
    public static class IntegrationClientExtensions
    {
        public static void AddIntegrationClients(this IServiceCollection services)
        {
            services.AddScoped<IGoogleBooksClient, GoogleBooksClient>();
            services.AddScoped<IWebServiceUriProvider, UriBuilder>();
        }
    }
}
