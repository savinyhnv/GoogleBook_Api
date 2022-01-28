using EdenLab.Tests.Integration.Sdk.DataCleanup;
using Flurl.Http;
using Simple.OData.Client;
using System.Text.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestTask.Creatio.Tests.Integration.Clients.Abstractions;
using TestTask.Creatio.Tests.Integration.Clients.Contracts;
using TestTask.Creatio.Tests.Integration.Domain.Entities;
using TestTask.Creatio.Tests.Integration.Extensions;

namespace TestTask.Creatio.Tests.Integration.Steps
{
    [Binding]
    public class BookCLientSteps
    {
        private readonly IProjectCreatioClient _creatioClient;
        private readonly IODataClient _oDataClient;
        private readonly IDataCleaner _dataCleaner;
        private readonly ScenarioContext _scenarioContext;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public BookCLientSteps(
            IProjectCreatioClient creatioClient,
            IODataClient dataClient,
            IDataCleaner dataCleaner,
            JsonSerializerOptions jsonSerializerOptions,
            ScenarioContext scenarioContext)
        {
            _creatioClient = creatioClient;
            _oDataClient = dataClient;
            _dataCleaner = dataCleaner;
            _jsonSerializerOptions = jsonSerializerOptions;
            _scenarioContext = scenarioContext;
        }

        [Given(@"Request json '(.*)' send")]
        public async Task GivenBookClientJsonSend(string jsonFile)
        {
            var json = await GetBookServiceRequestFromFileAsync(jsonFile);
            _scenarioContext["EnrichDbRequest"] = json;

            try
            {
                var response = await _creatioClient.BookClient.EnrichDbWithBooks(json);
                _scenarioContext.SetResponseStatusCode(response.StatusCode);
            }
            catch (FlurlHttpException httpException)
            {
                _scenarioContext.SetResponseStatusCode(httpException.StatusCode);
            }
        }

        [Given("Invalid request json was send")]
        public async Task GivenBookClientInvalidDataJsonSend(Table table)
        {
            var jsonFiles = table.CreateSet<JsonFilePath>();

            foreach(var jsonFile in jsonFiles)
            {
                var json = await GetBookServiceRequestFromFileAsync(jsonFile.Path);
                _scenarioContext["EnrichDbRequest"] = json;

                try
                {
                    var response = await _creatioClient.BookClient.EnrichDbWithBooks(json);
                    _scenarioContext.SetResponseStatusCode(response.StatusCode);
                }
                catch (FlurlHttpException httpException)
                {
                    _scenarioContext.SetResponseStatusCode(httpException.StatusCode);
                }
            }
        }

        private async Task<EnrichBooksRequest> GetBookServiceRequestFromFileAsync(string file)
        {
            var json = await File.ReadAllTextAsync(file);
            return JsonSerializer.Deserialize<EnrichBooksRequest>(json, _jsonSerializerOptions);
        }
    }
}
