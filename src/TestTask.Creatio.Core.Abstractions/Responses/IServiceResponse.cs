using EdenLab.FluentApi.Models;

namespace TestTask.Creatio.Core.Abstractions.Responses
{
    public interface IServiceResponse
    {
        bool IsSuccess
        {
            get;
        }

        HttpStatusCode ResultStatusCode
        {
            get;
        }

        int ItemsFound
        {
            get;
        }

        int ItemsLoaded
        {
            get;
        }

        int ItemsSaved
        {
            get;
        }

    }
}
