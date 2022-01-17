using EdenLab.FluentApi;
using EdenLab.FluentApi.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TestTask.Creatio.Extensions.DependencyInjection
{
    using EdenLab.Core.Web.Abstractions;

    public static class FluentApiExtensions
    {
        public static void UseFluentApi(this IApplication appBuilder)
        {
            FluentApi.Configure(opt =>
            {
                opt.ServiceProvider = appBuilder.ServiceProvider;
                opt.UriProvider = appBuilder.ServiceProvider.GetRequiredService<IWebServiceUriProvider>();
            });
        }
    }
}
