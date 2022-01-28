using TechTalk.SpecFlow;

namespace TestTask.Creatio.Tests.Integration.Extensions
{
    public static class ScenarioContextExtensions
    {
        public static void SetResponseStatusCode(this ScenarioContext scenarioContext, int? statusCode, string name = "ResponseStatusCode")
        {
            scenarioContext[name] = statusCode;
        }

        public static int? GetResponseStatusCode(this ScenarioContext scenarioContext, string name = "ResponseStatusCode")
        {
            return scenarioContext[name] as int?;
        }
    }
}
