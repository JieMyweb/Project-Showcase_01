using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr_service
{
    public interface IBookService
    {
        List<BookRes> GetBooks(BookReq req);
    }
}
