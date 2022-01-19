using EdenLab.Core.Entities;
using EdenLab.Core.Entities.Repositories;
using System.Threading.Tasks;
using TestTask.Creatio.Core.Abstractions.Repositories;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Core.Repositories
{
    public class PublisherRepository : EntityRepositoryBase<Account>, IPublisherRepository
    {
        public PublisherRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsPublisherExistsByNameAsync(string name) => await _dbContext
            .Entry<Account>()
            .AnyAsync(account => account.Name == name);

        public async Task<Account> GetPublisherByNameAsync(string name) => await _dbContext
            .Entry<Account>()
            .FirstOrDefaultAsync(account => account.Name == name);

    }
}
