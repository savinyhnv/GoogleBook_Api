using EdenLab.FluentApi.Models;
using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using TestTask.Creatio.Core.Abstractions.Integration;
using TestTask.Creatio.Core.Abstractions.Repositories;
using TestTask.Creatio.Core.Abstractions.Services;
using TestTask.Creatio.Core.Contracts;
using TestTask.Creatio.Core.Services;
using TestTask.Creatio.Data.Entities;
using TestTask.Creatio.Inegration.Dto.GoogleBooks;
using Xunit;

namespace TestTask.Core.Tests
{
    public class BookServiceTests
    {
        [Theory]
        [InlineData(true, 0)]
        [InlineData(false, 3)]
        public async void Should_Save_Correct_Quantity_Of_Books(bool condition, int quantity)
        {
            var bookRepo = Substitute.For<IBookRepository>();
            var bookInAuthorRepo = Substitute.For<IBookInAuthorRepository>();
            var gbClient = Substitute.For<IGoogleBooksClient>();
            var authorService = Substitute.For<IAuthorService>();
            var publisherService = Substitute.For<IPublisherService>();
            var bookService = new GoogleBookService(gbClient, bookRepo, bookInAuthorRepo, authorService, publisherService);

            bookRepo.IsExistsByGoogleId(null).Returns(condition);
            authorService.IsAuthorExistsByNameAsync(string.Empty).Returns(true);
            authorService.GetAuthorByNameAsync(string.Empty).Returns(new ELBaseAuthor() { ELName = string.Empty });
            authorService.AddNewAuthorAsync(default).Wait();
            publisherService.IsPublisherExistsByNameAsync("testPublisher").Returns(true);
            publisherService.GetPublisherByNameAsync(string.Empty).Returns(new Account() { Name = string.Empty });

            var data = new GoogleBooksClientResponse()
            {
                Kind = string.Empty,
                TotalItems = 3,
                Items = new List<GoogleBook>()
                    {
                        new GoogleBook()
                        {
                            VolumeInfo = new GoogleBookVolumeInfo()
                            {
                                Publisher = "TestPublisher"
                            }
                        },
                        new GoogleBook()
                        {
                            VolumeInfo = new GoogleBookVolumeInfo()
                            {
                                Publisher = "TestPublisher"
                            }
                        },
                        new GoogleBook()
                        {
                            VolumeInfo = new GoogleBookVolumeInfo()
                            {
                                Publisher = "TestPublisher"
                            }
                        }
                    }
            };

            var response = new HttpResponse<GoogleBooksClientResponse>()
            {
                StatusCode = new HttpStatusCode(System.Net.HttpStatusCode.OK),
                Data = data,
                Exception = null
            };

            gbClient.GetBooks(string.Empty).Returns((IHttpResponse<GoogleBooksClientResponse>)response);

            var result = await bookService.EnrichDbWithBooksAsync(string.Empty);

            result.As<GoogleBooksServiceResponse>().ItemsFound.Should().Be(3);
            result.As<GoogleBooksServiceResponse>().ItemsLoaded.Should().Be(3);
            result.As<GoogleBooksServiceResponse>().ItemsSaved.Should().Be(quantity);
        }
    }
}
