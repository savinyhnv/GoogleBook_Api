using Microsoft.Extensions.DependencyInjection;
using TestTask.Creatio.Core.Abstractions.Repositories;
using TestTask.Creatio.Core.Repositories;

namespace TestTask.Creatio.Extensions.DependencyInjection
{
    public static class RepositoryExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IBookInAuthorRepository, BookInAuthorRepository>();
        }
    }
}
