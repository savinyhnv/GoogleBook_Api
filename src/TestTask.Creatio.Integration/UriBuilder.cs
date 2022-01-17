using EdenLab.Core.Entities;
using EdenLab.FluentApi.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Integration
{
    public class UriBuilder : IWebServiceUriProvider
    {

        private readonly IDbContext _dbContext;

        public UriBuilder(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Uri> GetUriAsync(string apiId)
        {
            var address = await _dbContext.Entry<ELWebServiceInfo>()
               .FindAsync(Guid.Parse(apiId));

            return new Uri(address.ELUri, UriKind.Absolute);
        }
    }
}
