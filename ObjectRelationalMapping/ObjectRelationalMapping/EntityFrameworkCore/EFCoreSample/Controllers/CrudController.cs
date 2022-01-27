using EFCoreSample.DbContexts;
using EFCoreSample.Entitys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace EFCoreSample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        [HttpPost]
        public async Task<Object> InsertBook(Book book)
        {
            using (var db = new MyDbContext())
            {
                var obj = await db.Books.AddAsync(book);
                var count = await db.SaveChangesAsync();
                return new JsonResult(new { obj.Entity, count });
            }
        }

        [HttpGet]
        public async Task<Object> GetBooks()
        {
            using (var db = new MyDbContext())
            {
                var obj = await db.Books.ToListAsync();
                return new JsonResult(new { obj });
            }
        }

        [HttpPost]
        public async Task<Object> DeleteBook(int bookId)
        {
            using (var db = new MyDbContext())
            {
                var book = db.Books.Single(s => s.BookId == bookId);
                db.Books.Remove(book);
                var result = await db.SaveChangesAsync();
                return new JsonResult(new { result });
            }
        }

        [HttpPost]
        public async Task<Object> UpdateBook(Book book)
        {
            using (var db = new MyDbContext())
            {
                var result = db.Books.Single(s => s.BookId == book.BookId);
                result.Title = book.Title;
                result.Price = book.Price;
                result.PubTime = book.PubTime;
                result.AuthorName = book.AuthorName;
                db.Books.Update(result);
                var count = await db.SaveChangesAsync();
                return new JsonResult(new { count });
            }
        }
    }
}
