using System.Threading.Tasks;
using TestTask.Creatio.Core.Abstractions.Responses;

namespace TestTask.Creatio.Core.Abstractions.Services
{
    public interface IBookService
    {
        Task<IServiceResponse> EnrichDbWithBooksAsync(string searchKeyword);
    }
}
