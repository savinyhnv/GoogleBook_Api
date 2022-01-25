using EdenLab.FluentApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Creatio.Core.Abstractions.Integration;
using TestTask.Creatio.Core.Abstractions.Repositories;
using TestTask.Creatio.Core.Abstractions.Responses;
using TestTask.Creatio.Core.Abstractions.Services;
using TestTask.Creatio.Core.Contracts;
using TestTask.Creatio.Data.Entities;
using TestTask.Creatio.Inegration.Dto.GoogleBooks;

namespace TestTask.Creatio.Core.Services
{
    public class GoogleBookService : IBookService
    {
        private readonly IGoogleBooksClient _googleBooksClient;
        private readonly IBookRepository _bookRepository;
        private readonly IBookInAuthorRepository _bookInAuthorRepository;
        private readonly IAuthorService _authorService;
        private readonly IPublisherService _publisherService;

        public GoogleBookService(
            IGoogleBooksClient googleBooksClient, 
            IBookRepository bookRepository,
            IBookInAuthorRepository bookInAuthorRepository, 
            IAuthorService authorService, 
            IPublisherService publisherService)
        {
            this._googleBooksClient = googleBooksClient;
            this._bookRepository = bookRepository;
            this._bookInAuthorRepository = bookInAuthorRepository;
            this._authorService = authorService;
            this._publisherService = publisherService;
        }

        public async Task<IServiceResponse> EnrichDbWithBooksAsync(string searchKeyword)
        {
            var response = await _googleBooksClient.GetBooks(searchKeyword);
            var processedBooksCounter = 0;

            if(response != null && response.Data.Items.Count > 0) 
                processedBooksCounter = await ProcessResponseAsync(response);

            return new GoogleBooksServiceResponse(response, processedBooksCounter);
        }

        private async Task<int> ProcessResponseAsync(IHttpResponse<GoogleBooksClientResponse> response)
        {
            var processedBooksCounter = 0;

            foreach (var gBook in response.Data.Items.Where(gBook => _bookRepository.IsExistsByGoogleId(gBook.Id) is false))
            {
                await ProcessBookAsync(gBook);
                processedBooksCounter++;
            }

            return processedBooksCounter;
        }

        private async Task ProcessBookAsync(GoogleBook gBook)
        {
            var publisher = !string.IsNullOrEmpty(gBook.VolumeInfo.Publisher) ? await BuildPublisher(gBook.VolumeInfo.Publisher) : null;
            var elBook = BuildBook(gBook, publisher);
            _bookRepository.Add(elBook);
            await _bookRepository.SaveAsync();

            if (gBook.VolumeInfo.Authors is null || gBook.VolumeInfo.Authors.Count is 0)
                return;

            var authors = await BuildAuthorsAsync(gBook.VolumeInfo.Authors);
            var booksInAuthors = BuildBooksInAuthors(elBook, authors);
            await SaveBooksInAuthorsAsync(booksInAuthors);
        }

        private async Task<List<ELBaseAuthor>> BuildAuthorsAsync(List<string> authorsName)
        {
            var authors = new List<ELBaseAuthor>();

            foreach(var authorName in authorsName)
            {
                var isAuthorExists = await _authorService.IsAuthorExistsByNameAsync(authorName);
                var author = isAuthorExists ? await _authorService.GetAuthorByNameAsync(authorName) : new ELBaseAuthor {ELName = authorName};
                if(!isAuthorExists)
                    await _authorService.AddNewAuthorAsync(author);

                authors.Add(author);
            }

            return authors;
        }

        private async Task<Account> BuildPublisher(string publisherName)
        {
            var isPublisherExists = await _publisherService.IsPublisherExistsByNameAsync(publisherName);

            if(!isPublisherExists)
            {
                var publisher = new Account { Name = publisherName };
                await this._publisherService.AddNewPublisherAsync(publisher);
                return publisher;
            }

            return await _publisherService.GetPublisherByNameAsync(publisherName);
        }

        private ELBook BuildBook(GoogleBook gBook, Account publisher)
        {
            var book = new ELBook()
            {
                ELBookTitle = gBook.VolumeInfo.Title,
                ELBookSubtitle = gBook.VolumeInfo.Subtitle,
                ELGoogleIdentifyer = gBook.Id,
                ELBookPublisher = publisher != null ? publisher : null
            };

            if(publisher != null) book.ELBookPublisherId = publisher.Id;

            return book;
        }

        private List<ELBookInAuthor> BuildBooksInAuthors(ELBook book, List<ELBaseAuthor> authors)
        {
            var bookInAuthorList = new List<ELBookInAuthor>();

            foreach(var author in authors)
            {
                bookInAuthorList.Add(new ELBookInAuthor()
                {
                    ELBaseAuthorId = author.Id,
                    ELBookId = book.Id
                });
            }

            return bookInAuthorList;
        }

        private async Task SaveBooksInAuthorsAsync(List<ELBookInAuthor> booksInAuthors)
        {
            foreach(var bookInAuthor in booksInAuthors)
            {
                this._bookInAuthorRepository.Add(bookInAuthor);
                await this._bookInAuthorRepository.SaveAsync();
            }
        }
    }
}
