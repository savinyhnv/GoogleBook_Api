using EdenLab.Core.Entities.Repositories;
using System;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Core.Abstractions.Repositories
{
    public interface IPublisherRepository : IEntityRepository<Account>
    {
        Guid AddPublisher(Account account);
        bool IsPublisherExistsByName(string name);
        Account GetPublisherByName(string name);
    }
}
