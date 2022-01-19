using System.Threading.Tasks;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Core.Abstractions.Services
{
    public interface IPublisherService
    {
        Task<bool> IsPublisherExistsByNameAsync(string name);
        Task<Account> GetPublisherByNameAsync(string name);
        Task AddNewPublisherAsync(Account publisher);
    }
}
