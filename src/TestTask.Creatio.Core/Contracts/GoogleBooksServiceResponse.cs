using EdenLab.FluentApi.Models;
using TestTask.Creatio.Core.Abstractions.Responses;
using TestTask.Creatio.Inegration.Dto.GoogleBooks;
using HttpStatusCode = EdenLab.FluentApi.Models.HttpStatusCode;

namespace TestTask.Creatio.Core.Contracts
{
    public class GoogleBooksServiceResponse : IServiceResponse
    {
        public bool IsSuccess { get; }
        public HttpStatusCode ResultStatusCode { get;}
        public int ItemsFound { get;}
        public int ItemsLoaded { get;}

        public GoogleBooksServiceResponse(IHttpResponse<GoogleBooksClientResponse> response)
        {
            IsSuccess = response.Success;
            ResultStatusCode = response.StatusCode;
            ItemsFound = response.Data.TotalItems;
            ItemsLoaded = response.Data.Items.Count;
        }

    }
}
