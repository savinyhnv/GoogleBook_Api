using Xunit;
using NSubstitute;
using FluentAssertions;
using TestTask.Creatio.Integration.GoogleBooksCLient;
using Microsoft.Extensions.Logging;
using EdenLab.FluentApi.Models;
using TestTask.Creatio.Inegration.Dto.GoogleBooks;

namespace TestTask.Integration.Tests
{
    public class GoogleBooksClientTests
    {
        private readonly ILogger<GoogleBooksClient> _logger;
        private readonly GoogleBooksClient _client;
        public GoogleBooksClientTests()
        {
            _logger = Substitute.For<ILogger<GoogleBooksClient>>();
            _client = new GoogleBooksClient(_logger);
        }

        [Fact]
        public async void GbClient_Should_Return_CorrectTypeResponse()
        {
            var result = await _client.GetBooks("hello");
            result.Should().BeOfType<HttpResponse<GoogleBooksClientResponse>>();
        }

        [Theory]
        [InlineData("")]
        [InlineData("test")]
        [InlineData("123321")]
        public async void GbClient_Response_Should_Not_Be_Null(string data)
        {
            var result = await _client.GetBooks(data);
            result.Should().NotBeNull();
        }

        [Theory]
        [InlineData("test", 10)]
        [InlineData("123321", 10)]
        public async void GbClient_Should_Return_Correct_DataItemsQuantity_(string keyWord, int quantity)
        {
            var result = await _client.GetBooks(keyWord);
            result.Data.Items.Count.Should().Be(quantity);
        }
    }
}