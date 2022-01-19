using EdenLab.Core.Web;
using System.Threading.Tasks;
using System.Web.Http;
using TestTask.Creatio.Api.Contracts;
using TestTask.Creatio.Core.Abstractions.Services;

namespace TestTask.Creatio.Api.Controllers
{
    [RoutePrefix("api/books")]
    public class BookController : ApiControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            this._bookService = bookService;
        }

        [HttpPost]
        [Route("google/enrich")]
        public async Task<IHttpActionResult> EnrichDbWithBooks([FromBody] GetBookRequest request)
        {
            var result = await _bookService.EnrichDbWithBooksAsync(request.SearchKeyword);
            return Ok(result);
        }
    }
}
