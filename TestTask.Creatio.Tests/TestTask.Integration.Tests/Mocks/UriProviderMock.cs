using EdenLab.FluentApi.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Integration.Tests.Mocks
{
    public class UriProviderMock : IWebServiceUriProvider
    {
        public async Task<Uri> GetUriAsync(string apiId)
        {
            var res = await Task.Factory.StartNew(() => BuildUri());
            return res;
        }

        private Uri BuildUri() => new Uri("https://www.googleapis.com/books/v1/volumes?q={keyword}", UriKind.Absolute);
    }
}
