using FluentAssertions;
using NSubstitute;
using TestTask.Creatio.Core.Abstractions.Repositories;
using TestTask.Creatio.Core.Services;
using TestTask.Creatio.Data.Entities;
using Xunit;

namespace TestTask.Core.Tests
{
    public class PublisherServiceTests
    {
        [Fact]
        public async void Service_Should_Return_Entity()
        {
            var publisherRepository = Substitute.For<IPublisherRepository>();
            var service = new PublisherService(publisherRepository);

            publisherRepository.GetPublisherByNameAsync(string.Empty).Returns(new Account());

            var result = await service.GetPublisherByNameAsync(string.Empty);

            result.Should().NotBeNull();
            result.Should().BeOfType<Account>();
        }

        [Fact]
        public async void Service_Should_Return_Null()
        {
            var publisherRepository = Substitute.For<IPublisherRepository>();
            var service = new PublisherService(publisherRepository);
            Account nullPublisher = null;

            publisherRepository.GetPublisherByNameAsync(string.Empty).Returns(nullPublisher);

            var result = await service.GetPublisherByNameAsync(string.Empty);

            result.Should().BeNull();
        }

        [Fact]
        public async void Service_Should_Return_True()
        {
            var publisherRepository = Substitute.For<IPublisherRepository>();
            var service = new PublisherService(publisherRepository);

            publisherRepository.IsPublisherExistsByNameAsync(string.Empty).Returns(true);

            var result = await service.IsPublisherExistsByNameAsync(string.Empty);

            result.Should().BeTrue();
        }

        [Fact]
        public async void Service_Should_Return_False()
        {
            var publisherRepository = Substitute.For<IPublisherRepository>();
            var service = new PublisherService(publisherRepository);

            publisherRepository.IsPublisherExistsByNameAsync(string.Empty).Returns(false);

            var result = await service.IsPublisherExistsByNameAsync(string.Empty);

            result.Should().BeFalse();
        }
    }
}
