using EdenLab.Core.Entities;
using EdenLab.Core.Entities.Repositories;
using System;
using System.Data;
using TestTask.Creatio.Core.Abstractions.Repositories;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Core.Repositories
{
    public class BookInAuthorRepository : EntityRepositoryBase<ELBookInAuthor>, IBookInAuthorRepository
    {
        private readonly IDbConnection _dbConnection;

        public BookInAuthorRepository(IDbContext dbContext, IDbConnection dbConnection) : base(dbContext)
        {
            this._dbConnection = dbConnection;
        }

        public Guid AddBookInAuthor(ELBookInAuthor bookInAuthor) => _dbContext.Entry<ELBookInAuthor>().Add(bookInAuthor);
    }
}
