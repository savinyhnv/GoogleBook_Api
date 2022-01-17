using EdenLab.Core.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Core.Abstractions.Repositories
{
    public interface IBookInAuthorRepository : IEntityRepository<ELBookInAuthor>
    {
        Guid AddBookInAuthor(ELBookInAuthor bookInAuthor);
    }
}
