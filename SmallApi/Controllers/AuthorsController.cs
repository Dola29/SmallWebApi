using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
    public class AuthorsController: ControllerBase
    {
        private ApplicationDbContext context;

        public AuthorsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Author>> Get()
        {
            return context.Authors.Include(x => x.Books).ToList();
        }

        [HttpGet("first")]
        public ActionResult<Author> GetFirstAuthor()
        {
            return context.Authors.FirstOrDefault();
        }

        //Get api/authors/5 o api/authors/5/unnombre
        [HttpGet("{id}", Name = "GetAuthor")]
        public async Task<ActionResult<Author>> Get(int id, [BindRequired] string param2)
        {
            var author = await context.Authors.Include(x => x.Books).FirstOrDefaultAsync(x => x.Id == id);
            if(author == null)
            {
                return NotFound();
            }

            return author; 
        }

        [HttpPost]
        public ActionResult Post([FromBody] Author author)
        {
            TryValidateModel(author);
            context.Authors.Add(author);
            context.SaveChanges();
            return new CreatedAtRouteResult("GetAuthor", new { id = author.Id}, author);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Author value)
        {
            if(id != value.Id)
            {
                return BadRequest();
            }
            context.Entry(value).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Author> Delete(int id)
        {
            var author = context.Authors.FirstOrDefault(x => x.Id == id);
            if (author == null)
            {
                return NotFound();
            }

            context.Authors.Remove(author);
            context.SaveChanges();
            return Ok();
        }

    }
}
