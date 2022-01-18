using EdenLab.Core.Caching.Extensions;
using EdenLab.Core.Db.Extensions;
using EdenLab.Core.Entities;
using EdenLab.Core.Entities.Extensions;
using EdenLab.Core.Web.Hosting;
using EdenLab.Common.Extensions;
using EdenLab.Logging.Extensions;
using EdenLab.Identities.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Hosting;
using Terrasoft.Core;
using TestTask.Creatio.Core;
using TestTask.Creatio.Data;
using EdenLab.Core.Web.Abstractions;
using TestTask.Creatio.Extensions.DependencyInjection;
using TestTask.Creatio.Api;
using EdenLab.Core.Web.Extensions;
using TestTask.Creatio.Integration;
using EdenLab.MessageBroker.Extensions;

namespace ELBase.Files.cs
{
    public class Startup : StartupBase
    {
        public Startup(AppConnection appConnection) : base(appConnection) { }

        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            base.ConfigureServices(services, configuration);
            services.AddCreatioLogging(configuration, HostingEnvironment.ApplicationVirtualPath);
            services.AddEntityFileGeneration(x => x.Path = "src/");
            services.AddCaching(builder =>
            {
                builder.UseMemory();
                builder.UseRedis(configuration);
            });
            services.AddDbContext();
            services.AddControllers(typeof(ITestTaskApiAssemblyMarker));
            services.AddDbConnection(config => config.UseMssql().WithSysSettings().WithIdentities());
            services.AddEntityMapping(x => x.AddProfiles(typeof(ITestTaskDataAssemblyMarker)));
            services.AddAutoMapper(
                typeof(Startup),
                typeof(ITestTaskCoreAssemblyMarker),
                typeof(ITestTaskApiAssemblyMarker),
                typeof(ITestTaskIntegrationAssemblyMarker));
            services.AddDomainServices();
            services.AddRepositories();
            services.AddIntegrationClients();
        }

        public override void Configure(IApplication app)
        {
            base.Configure(app);
            app.UseFluentApi();
        }
    }
}
