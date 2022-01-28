using FluentAssertions;
using TechTalk.SpecFlow;
using TestTask.Creatio.Tests.Integration.Extensions;

namespace TestTask.Creatio.Tests.Integration.Steps
{
    [Binding]
    public class GenericSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public GenericSteps(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        [Then(@"Response status code should be (.*)")]
        public void ThenResponseStatusCodeShouldBe(int statusCode)
        {
            var responseStatusCode = _scenarioContext.GetResponseStatusCode();
            responseStatusCode.Should().Be(statusCode);
        }
    }
}
