using TestTask.Creatio.Core.Abstractions.Repositories;
using TestTask.Creatio.Core.Abstractions.Services;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Core.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherService(IPublisherRepository accountRepository)
        {
            this._publisherRepository = accountRepository;
        }
        public void AddNewPublisher(Account publisher)
        {
            _publisherRepository.Add(publisher);
            _publisherRepository.Save();
        }
        
        public bool IsPublisherExistsByName(string name) => this._publisherRepository.IsPublisherExistsByName(name);
        public Account GetPublisherByName(string name) => this._publisherRepository.GetPublisherByName(name);
    }
}