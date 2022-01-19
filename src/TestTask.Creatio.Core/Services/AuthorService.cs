using System.Threading.Tasks;
using TestTask.Creatio.Core.Abstractions.Repositories;
using TestTask.Creatio.Core.Abstractions.Services;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }


        public async Task AddNewAuthorAsync(ELBaseAuthor author)
        {
            _authorRepository.Add(author);
            await _authorRepository.SaveAsync();
        }
        public async Task<bool> IsAuthorExistsByNameAsync(string name) => await _authorRepository.IsAuthorExistsByNameAsync(name);
        
        public async Task<ELBaseAuthor> GetAuthorByNameAsync(string name) => await _authorRepository.GetAuthorByNameAsync(name);
    }
}
