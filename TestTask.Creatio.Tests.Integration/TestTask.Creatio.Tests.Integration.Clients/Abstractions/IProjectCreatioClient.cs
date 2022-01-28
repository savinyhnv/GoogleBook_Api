using EdenLab.Tests.Integration.Sdk.Clients;

namespace TestTask.Creatio.Tests.Integration.Clients.Abstractions
{
    public interface IProjectCreatioClient : ICreatioClient
    {
        IBookClient BookClient { get; }
    }
}
