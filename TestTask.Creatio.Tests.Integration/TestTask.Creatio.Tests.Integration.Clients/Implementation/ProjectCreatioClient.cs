using EdenLab.Tests.Integration.Sdk.Clients;
using EdenLab.Tests.Integration.Sdk.Clients.Implementation;
using TestTask.Creatio.Tests.Integration.Clients.Abstractions;

namespace TestTask.Creatio.Tests.Integration.Clients.Implementation
{
    public class ProjectCreatioClient : CreatioClient, IProjectCreatioClient
    {
        public IBookClient BookClient { get; }

        public ProjectCreatioClient(
            IBookClient bookClient,
            IProcessClient processClient,
            IIdentitiesClient identitiesClient) :
            base(processClient, identitiesClient)
        {
            BookClient = bookClient;
        }
    }
}
