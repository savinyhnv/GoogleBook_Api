using EdenLab.Core.Entities.Extensions;
using EdenLab.Core.Web.Extensions;
using EdenLab.Core.Web.Hosting;
using Terrasoft.Core;
using TestTask.Creatio.Data;

namespace ELBase.Files.cs
{
    public class Program
    {
        public static void Main(AppConnection appConnection)
        {
            WebHost.Create<Startup>(appConnection)
                .UseEntityFileGeneration<ITestTaskDataAssemblyMarker>(appConnection)
                .Build()
                .RunNetFramework();
        }
    }
}
