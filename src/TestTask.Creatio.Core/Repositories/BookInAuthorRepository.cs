using EdenLab.Core.Entities;
using EdenLab.Core.Entities.Repositories;
using System.Data;
using TestTask.Creatio.Core.Abstractions.Repositories;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Core.Repositories
{
    public class BookInAuthorRepository : EntityRepositoryBase<ELBookInAuthor>, IBookInAuthorRepository
    {
        public BookInAuthorRepository(IDbContext dbContext) : base(dbContext)
        {}
    }
}
