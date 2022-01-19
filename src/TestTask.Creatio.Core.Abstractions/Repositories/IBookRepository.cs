using EdenLab.Core.Entities.Repositories;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Core.Abstractions.Repositories
{
    public interface IBookRepository : IEntityRepository<ELBook>
    {         
        bool IsExistsByGoogleId(string gId);
    }
}
