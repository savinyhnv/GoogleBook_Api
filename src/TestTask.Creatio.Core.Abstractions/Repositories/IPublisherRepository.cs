using EdenLab.Core.Entities.Repositories;
using System.Threading.Tasks;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Core.Abstractions.Repositories
{
    public interface IPublisherRepository : IEntityRepository<Account>
    {
        Task<bool> IsPublisherExistsByNameAsync(string name);
        Task<Account> GetPublisherByNameAsync(string name);
    }
}
