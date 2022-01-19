using EdenLab.Core.Entities;
using EdenLab.Core.Entities.Repositories;
using TestTask.Creatio.Core.Abstractions.Repositories;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Core.Repositories
{
    public class BookRepository : EntityRepositoryBase<ELBook>, IBookRepository
    {
        public BookRepository(IDbContext dbContext) : base(dbContext) 
        {
        }

        public bool IsExistsByGoogleId(string gId) => 
            _dbContext.Entry<ELBook>()
            .Any(elBook => elBook.ELGoogleIdentifyer == gId);
        
    }
}
