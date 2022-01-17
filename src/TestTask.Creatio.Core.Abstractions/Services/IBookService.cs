using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestTask.Creatio.Core.Abstractions.Responses;

namespace TestTask.Creatio.Core.Abstractions.Services
{
    public interface IBookService
    {
        Task<IServiceResponse> FillDbWithBooksAsync(string searchKeyword);
    }
}
