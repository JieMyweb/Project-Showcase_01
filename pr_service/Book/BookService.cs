using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using pr_model.Models;

namespace pr_service
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly PGDB_01Context _context;

        public BookService(IMapper mapper, PGDB_01Context context)
        {
            _mapper = mapper;
            _context = context;
        }

        public List<BookRes> GetBooks(BookReq req)
        {
            // 使用單行的 LINQ 查詢方法鏈進行查詢和篩選
            IQueryable<Book> query = _context.Set<Book>();
            if (req.Id > 0)
            {
                query = _context.Set<Book>().Where(x => x.Id == req.Id);
            }
            if (req.Type > 0)
            {
                query = _context.Set<Book>().Where(x => x.Type == req.Type);
            }

            List<Book> books = query.ToList();
            // 映射並返回結果
            return _mapper.Map<List<BookRes>>(books);
        }
    }
}
