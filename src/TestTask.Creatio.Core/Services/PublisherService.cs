using System.Threading.Tasks;
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
        public async Task AddNewPublisherAsync(Account publisher)
        {
            _publisherRepository.Add(publisher);
            await _publisherRepository.SaveAsync();
        }
        
        public async Task<bool> IsPublisherExistsByNameAsync(string name) => await _publisherRepository.IsPublisherExistsByNameAsync(name);
        public async Task<Account> GetPublisherByNameAsync(string name) => await _publisherRepository.GetPublisherByNameAsync(name);
    }
}