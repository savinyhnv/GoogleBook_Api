using EdenLab.FluentApi.Models;
using NSubstitute;
using System.Collections.Generic;
using System.Web.Http.Results;
using TestTask.Creatio.Api.Contracts;
using TestTask.Creatio.Api.Controllers;
using TestTask.Creatio.Core.Abstractions.Services;
using TestTask.Creatio.Core.Abstractions.Responses;
using TestTask.Creatio.Core.Contracts;
using TestTask.Creatio.Inegration.Dto.GoogleBooks;
using Xunit;
using FluentAssertions;

namespace TestTask.Api.Tests
{
    public class ControllerTests
    {
        [Fact]
        public async void Controller_Should_Return_Ok()
        {
            var gbService = Substitute.For<IBookService>();
            var gbClientResponse = new HttpResponse<GoogleBooksClientResponse>()
            {
                StatusCode = new HttpStatusCode(System.Net.HttpStatusCode.OK),
                Data = new GoogleBooksClientResponse()
                {
                    Kind = string.Empty,
                    TotalItems = 3,
                    Items = new List<GoogleBook>()
                    {
                        new GoogleBook() { VolumeInfo = new GoogleBookVolumeInfo(){Publisher = "TestPublisher_1"}},
                        new GoogleBook() { VolumeInfo = new GoogleBookVolumeInfo(){Publisher = "TestPublisher_2"}},
                        new GoogleBook() { VolumeInfo = new GoogleBookVolumeInfo(){Publisher = "TestPublisher_3"}},
                    }
                },
                Exception = null
            };
            var gbServiceResponse = new GoogleBooksServiceResponse(gbClientResponse, 3);
            gbService.EnrichDbWithBooksAsync(string.Empty).Returns(gbServiceResponse);

            var controller = new BookController(gbService);
            var result = await controller.EnrichDbWithBooks(new GetBookRequest() { SearchKeyword = string.Empty });

            var content = result.As<OkNegotiatedContentResult<IServiceResponse>>().Content;

            content.IsSuccess.Should().BeTrue();
            content.ResultStatusCode.Code.Should().Be(System.Net.HttpStatusCode.OK);
            content.ItemsSaved.Should().Be(3);


        }
    }
}