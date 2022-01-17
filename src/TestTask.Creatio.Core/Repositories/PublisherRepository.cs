using EdenLab.Core.Entities;
using EdenLab.Core.Entities.Repositories;
using System;
using System.Data;
using TestTask.Creatio.Core.Abstractions.Repositories;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Core.Repositories
{
    public class PublisherRepository : EntityRepositoryBase<Account>, IPublisherRepository
    {
        private readonly IDbConnection _dbConnection;

        public PublisherRepository(IDbContext dbContext, IDbConnection dbConnection) : base(dbContext)
        {
            this._dbConnection = dbConnection;
        }

        public Guid AddPublisher(Account account) => _dbContext.Entry<Account>().Add(account);
        public bool IsPublisherExistsByName(string name) => _dbContext.Entry<Account>().Any(account => account.Name == name);
        public Account GetPublisherByName(string name) => _dbContext.Entry<Account>().FirstOrDefault(account => account.Name == name);

    }
}
