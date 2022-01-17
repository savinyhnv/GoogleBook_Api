using EdenLab.FluentApi.Models;
using System.Threading.Tasks;
using TestTask.Creatio.Inegration.Dto.GoogleBooks;

namespace TestTask.Creatio.Core.Abstractions.Integration
{
    public interface IGoogleBooksClient
    {
        Task<IHttpResponse<GoogleBooksClientResponse>> GetBooks(string searchKeyword);
    }
}
