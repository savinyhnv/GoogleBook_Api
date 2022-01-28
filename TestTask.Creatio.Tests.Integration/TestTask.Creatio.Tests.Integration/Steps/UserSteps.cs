using EdenLab.Tests.Integration.Sdk.Clients;
using EdenLab.Tests.Integration.Sdk.Configuration;
using EdenLab.Tests.Integration.Sdk.Contracts;
using Microsoft.Extensions.Options;
using TechTalk.SpecFlow;

namespace TestTask.Creatio.Tests.Integration.Steps
{
    [Binding]
    public class UserSteps
    {
        private readonly IIdentitiesClient _identitiesClient;
        private readonly IOptions<CreatioOptions> _options;

        public UserSteps(IIdentitiesClient identitiesClient, IOptions<CreatioOptions> options)
        {
            _identitiesClient = identitiesClient;
            _options = options;
        }

        [Given("Admin user logged in")]
        public async Task GivenAdminUserLoggedIn()
        {
            var test = new LoginRequest()
            {
                UserName = _options.Value.Admin.User,
                UserPassword = _options.Value.Admin.Password
            };

            await _identitiesClient.LoginAsync(new LoginRequest
            {
                UserName = _options.Value.Admin.User,
                UserPassword = _options.Value.Admin.Password
            });
        }
    }
}
