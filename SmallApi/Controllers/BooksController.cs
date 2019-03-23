using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmallApi.Contexts;
using SmallApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController: ControllerBase
    {
        private ApplicationDbContext context;

        public BooksController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return context.Books.Include(x => x.Author).ToList();
        }

        [HttpGet("{id}", Name = "GetBook")]
        public ActionResult<Book> Get(int id)
        {
            var book = context.Books.Include(x => x.Author).FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
            return new CreatedAtRouteResult("GetBook", new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book value)
        {
            if (id != value.Id)
            {
                return BadRequest();
            }
            context.Entry(value).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Book> Delete(int id)
        {
            var book = context.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            context.Books.Remove(book);
            context.SaveChanges();
            return Ok();
        }
    }
}
 