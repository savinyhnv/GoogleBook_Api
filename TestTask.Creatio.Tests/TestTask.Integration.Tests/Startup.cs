using EdenLab.Core.Entities;
using EdenLab.FluentApi;
using EdenLab.FluentApi.Configuration;
using EdenLab.UnitTestsSdk.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSubstitute;
using System;
using Terrasoft.Core;
using TestTask.Creatio.Data.Entities;
using TestTask.Creatio.Integration;
using TestTask.Integration.Tests.Mocks;
using UriBuilder = TestTask.Creatio.Integration.UriBuilder;

namespace TestTask.Integration.Tests
{
    public class Startup
    {
        public void ConfigureHost(IHostBuilder hostBuilder)
        {
            hostBuilder.MockLogging().MockScheduler();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var appConnection = new AppConnection();
            var userConnection = new UserConnection(appConnection);
            var dbContext = Substitute.For<IDbContext>();
            var uriBuilder = Substitute.For<UriBuilder>(dbContext);

            services.AddScoped(_ => userConnection);
            services.AddTransient(_ => dbContext);
            services.AddTransient<IWebServiceUriProvider, UriProviderMock>();
            var serviceProvider = services.BuildServiceProvider();

            FluentApi.Configure(options =>
            {
                options.ServiceProvider = serviceProvider;
                options.UriProvider = serviceProvider.GetRequiredService<IWebServiceUriProvider>();
            });
        }
    }
}
