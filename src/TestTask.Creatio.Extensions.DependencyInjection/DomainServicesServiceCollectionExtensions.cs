using Microsoft.Extensions.DependencyInjection;
using TestTask.Creatio.Core.Abstractions.Services;
using TestTask.Creatio.Core.Services;

namespace TestTask.Creatio.Extensions.DependencyInjection
{
    public static class DomainServicesServiceCollectionExtensions
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, GoogleBookService>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IAuthorService, AuthorService>();
        }
    }
}
