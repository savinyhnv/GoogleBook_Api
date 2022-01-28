using FluentAssertions;
using NSubstitute;
using TestTask.Creatio.Core.Abstractions.Repositories;
using TestTask.Creatio.Core.Services;
using TestTask.Creatio.Data.Entities;
using Xunit;

namespace TestTask.Core.Tests
{
    public class AuthorServiceTests
    {
        [Fact]
        public async void Service_Should_Return_Entity()
        {
            var authorRepository = Substitute.For<IAuthorRepository>();
            var service = new AuthorService(authorRepository);

            authorRepository.GetAuthorByNameAsync(string.Empty).Returns(new ELBaseAuthor());

            var result = await service.GetAuthorByNameAsync(string.Empty);

            result.Should().NotBeNull();
            result.Should().BeOfType<ELBaseAuthor>();
        }

        [Fact]
        public async void Service_Should_Return_Null()
        {
            var authorRepository = Substitute.For<IAuthorRepository>();
            var service = new AuthorService(authorRepository);
            ELBaseAuthor nullAuthor = null;

            authorRepository.GetAuthorByNameAsync(string.Empty).Returns(nullAuthor);

            var result = await service.GetAuthorByNameAsync(string.Empty);

            result.Should().BeNull();
        }

        [Fact]
        public async void Service_Should_Return_True()
        {
            var authorRepository = Substitute.For<IAuthorRepository>();
            var service = new AuthorService(authorRepository);

            authorRepository.IsAuthorExistsByNameAsync(string.Empty).Returns(true);

            var result = await service.IsAuthorExistsByNameAsync(string.Empty);

            result.Should().BeTrue();
        }

        [Fact]
        public async void Service_Should_Return_False()
        {
            var authorRepository = Substitute.For<IAuthorRepository>();
            var service = new AuthorService(authorRepository);

            authorRepository.IsAuthorExistsByNameAsync(string.Empty).Returns(false);

            var result = await service.IsAuthorExistsByNameAsync(string.Empty);

            result.Should().BeFalse();
        }
    }
}