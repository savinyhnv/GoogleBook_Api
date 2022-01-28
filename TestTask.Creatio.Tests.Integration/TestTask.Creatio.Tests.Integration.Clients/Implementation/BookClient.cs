using EdenLab.Tests.Integration.Sdk.Configuration;
using EdenLab.Tests.Integration.Sdk.Extensions;
using Microsoft.Extensions.Options;
using TestTask.Creatio.Tests.Integration.Clients.Abstractions;
using TestTask.Creatio.Tests.Integration.Clients.Contracts;

namespace TestTask.Creatio.Tests.Integration.Clients.Implementation
{
    public class BookClient : IBookClient
    {
        private readonly IOptions<CreatioOptions> _creatioOptions;

        public BookClient(IOptions<CreatioOptions> creatioOptions)
        {
            _creatioOptions = creatioOptions;
        }

        public async Task<IFlurlResponse> EnrichDbWithBooks(EnrichBooksRequest request)
        {
            return await(_creatioOptions.Value.ApiUrl + "/books/google/enrich")
            .WithCreatioCookies().PostJsonAsync(request);
        }
    }
}
