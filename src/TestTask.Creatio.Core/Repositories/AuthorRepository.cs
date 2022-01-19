using EdenLab.Core.Entities;
using EdenLab.Core.Entities.Repositories;
using System.Data;
using System.Threading.Tasks;
using TestTask.Creatio.Core.Abstractions.Repositories;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Core.Repositories
{
    public class AuthorRepository : EntityRepositoryBase<ELBaseAuthor>, IAuthorRepository
    {
        public AuthorRepository(IDbContext dbContext) : base(dbContext) 
        {}

        public async Task<bool> IsAuthorExistsByNameAsync(string name) => await _dbContext
            .Entry<ELBaseAuthor>()
            .AnyAsync(author => author.ELName == name);

        public async Task<ELBaseAuthor> GetAuthorByNameAsync(string name) => await _dbContext
            .Entry<ELBaseAuthor>()
            .FirstOrDefaultAsync(author => author.ELName == name);
        
    }
}
