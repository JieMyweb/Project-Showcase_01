using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pr_model;
using pr_Model.Models;
using pr_service;

namespace pr_server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpPost]
        public ApiResult GetBooks(BookReq req)
        {
            ApiResult apiresult = new ApiResult() { IsSuccess=true};
            apiresult.Result = _bookService.GetBooks(req);
            return apiresult;
        }
    }
}
