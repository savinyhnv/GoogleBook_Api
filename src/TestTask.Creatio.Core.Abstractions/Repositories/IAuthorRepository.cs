using EdenLab.Core.Entities.Repositories;
using System;
using System.Collections.Generic;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Core.Abstractions.Repositories
{
    public interface IAuthorRepository : IEntityRepository<ELBaseAuthor>
    {
        List<Guid> AddAuthors(List<ELBaseAuthor> author);
        bool IsAuthorExistsByName(string name);
        Guid GetAuthorIdByName(string name);
        ELBaseAuthor GetAuthorNyName(string name);
    }
}
