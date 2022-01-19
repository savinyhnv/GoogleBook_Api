using EdenLab.Core.Entities.Repositories;
using System.Threading.Tasks;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Core.Abstractions.Repositories
{
    public interface IAuthorRepository : IEntityRepository<ELBaseAuthor>
    {
        Task<bool> IsAuthorExistsByNameAsync(string name);
        Task<ELBaseAuthor> GetAuthorByNameAsync(string name);
    }
}
