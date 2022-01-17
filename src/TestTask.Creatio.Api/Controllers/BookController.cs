using EdenLab.Core.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TestTask.Creatio.Api.Contracts;
using TestTask.Creatio.Core.Abstractions.Responses;
using TestTask.Creatio.Core.Abstractions.Services;

namespace TestTask.Creatio.Api.Controllers
{
    [RoutePrefix("api/bookService")]
    public class BookController : ApiControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            this._bookService = bookService;
        }

        [HttpPost]
        [Route("getBooks")]
        public async Task<IServiceResponse> FillDbWithBooks([FromBody] GetBookRequest request)
        {
            var result = await _bookService.FillDbWithBooksAsync(request.SearchKeyword);
            return result;
        }


    }
}
