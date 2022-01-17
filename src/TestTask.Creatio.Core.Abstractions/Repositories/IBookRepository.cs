using EdenLab.Core.Entities.Repositories;
using System;
using TestTask.Creatio.Data.Entities;
using TestTask.Creatio.Inegration.Dto.GoogleBooks;

namespace TestTask.Creatio.Core.Abstractions.Repositories
{
    public interface IBookRepository : IEntityRepository<ELBook>
    {
        Guid AddBook(ELBook book);
        bool IsExistsByGoogleId(string gId);
    }
}
