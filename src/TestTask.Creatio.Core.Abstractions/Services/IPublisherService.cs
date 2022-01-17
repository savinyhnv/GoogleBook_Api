using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Core.Abstractions.Services
{
    public interface IPublisherService
    {
        bool IsPublisherExistsByName(string name);
        Account GetPublisherByName(string name);
        void AddNewPublisher(Account publisher);
    }
}
