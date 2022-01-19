using System.Threading.Tasks;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Core.Abstractions.Services
{
    public interface IAuthorService
    {
        Task<bool> IsAuthorExistsByNameAsync(string name);
        Task<ELBaseAuthor> GetAuthorByNameAsync(string name);
        Task AddNewAuthorAsync(ELBaseAuthor author);
    }
}
