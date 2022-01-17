using EdenLab.Core.Entities;
using EdenLab.Core.Entities.Repositories;
using System;
using System.Data;
using TestTask.Creatio.Core.Abstractions.Repositories;
using TestTask.Creatio.Data.Entities;
using TestTask.Creatio.Inegration.Dto.GoogleBooks;

namespace TestTask.Creatio.Core.Repositories
{
    public class BookRepository : EntityRepositoryBase<ELBook>, IBookRepository
    {
        public BookRepository(IDbContext dbContext) : base(dbContext) 
        {
        }

        public Guid AddBook(ELBook book) => _dbContext.Entry<ELBook>().Add(book);
        public bool IsExistsByGoogleId(string gId)
        {
            return _dbContext.Entry<ELBook>().Any(elBook => elBook.ELGoogleIdentifyer == gId);
        }
        
    }
}
