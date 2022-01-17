using EdenLab.FluentApi.Models;
using System;
using System.Collections.Generic;
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

        public GoogleBookService(IGoogleBooksClient googleBooksClient, IBookRepository bookRepository,
            IBookInAuthorRepository bookInAuthorRepository, IAuthorService authorService, IPublisherService publisherService)
        {
            this._googleBooksClient = googleBooksClient;
            this._bookRepository = bookRepository;
            this._bookInAuthorRepository = bookInAuthorRepository;
            this._authorService = authorService;
            this._publisherService = publisherService;
        }

        public async Task<IServiceResponse> FillDbWithBooksAsync(string searchKeyword)
        {
            var response = await this._googleBooksClient.GetBooks(searchKeyword);

            if(response != null && response.Data.Items.Count > 0) 
                await ProcessResponseAsync(response);

            return new GoogleBooksServiceResponse(response);
        }

        public async Task ProcessResponseAsync(IHttpResponse<GoogleBooksClientResponse> response)
        {
            foreach (var gBook in response.Data.Items)
            {
                if (!_bookRepository.IsExistsByGoogleId(gBook.Id))
                    await ProcessBook(gBook);
            }
        }

        public async Task ProcessBook(GoogleBook gBook)
        {
            var publisher = !String.IsNullOrEmpty(gBook.VolumeInfo.Publisher) ? BuildPublisher(gBook.VolumeInfo.Publisher) : null;
            var elBook = BuildBook(gBook, publisher);
            this._bookRepository.Add(elBook);
            this._bookRepository.Save();

            if (gBook.VolumeInfo.Authors == null || gBook.VolumeInfo.Authors.Count == 0)
                return;

            var authors = BuildAuthors(gBook.VolumeInfo.Authors);

            var booksInAuthors = BuildBooksInAuthors(elBook, authors);
            await SaveBooksInAuthorsAsync(booksInAuthors);
        }

        private List<ELBaseAuthor> BuildAuthors(List<string> authorsName)
        {
            var authors = new List<ELBaseAuthor>();

            foreach(var authorName in authorsName)
            {
                var isAuthorExists = _authorService.IsAuthorExistsByName(authorName);
                var author = isAuthorExists ? _authorService.GetAuthorByName(authorName) : new ELBaseAuthor {ELName = authorName};
                if(!isAuthorExists)
                    _authorService.AddNewAuthor(author);

                authors.Add(author);
            }

            return authors;
        }
        private Account BuildPublisher(string publisherName)
        {
            var isPublisherExists = _publisherService.IsPublisherExistsByName(publisherName);

            if(!isPublisherExists)
            {
                var publisher = new Account { Name = publisherName };
                this._publisherService.AddNewPublisher(publisher);
                return publisher;
            }

            return _publisherService.GetPublisherByName(publisherName);
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
