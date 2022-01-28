using EdenLab.Tests.Integration.Sdk.Configuration;
using EdenLab.Tests.Integration.Sdk.Extensions;
using EdenLab.Tests.Integration.Sdk.Identities;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SolidToken.SpecFlow.DependencyInjection;
using System.Text.Json;
using TestTask.Creatio.Tests.Integration.Extensions;

namespace TestTask.Creatio.Tests.Integration
{
    public class Startup
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var configuration = GetConfiguration();
            var serviceCollection = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
            serviceCollection.AddSingleton(configuration);
            serviceCollection.AddScoped<ICurrentUserContext, CurrentUserContext>();
            serviceCollection.AddClients();
            serviceCollection.AddOData(configuration);
            serviceCollection.AddDataCleaner();
            serviceCollection.Configure<CreatioOptions>(configuration.GetSection("CreatioClient"));

            serviceCollection.AddSingleton(new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            FlurlHttp.Configure(settings =>
            {
                var jsonSettings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                settings.JsonSerializer = new NewtonsoftJsonSerializer(jsonSettings);
            });

            return serviceCollection;
        }

        private static IConfiguration GetConfiguration()
        {
            var environment = "dev";

            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder
                .AddEnvironmentVariables()
                .AddJsonFile("appSettings.json")
                .AddJsonFile($"appSettings.{environment}.json")
                .Build();

            return configurationBuilder.Build();
        }
    }
}
