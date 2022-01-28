using TestTask.Creatio.Tests.Integration.Clients.Contracts;

namespace TestTask.Creatio.Tests.Integration.Clients.Abstractions
{
    public interface IBookClient
    {
        Task<IFlurlResponse> EnrichDbWithBooks(EnrichBooksRequest request);
    }
}
