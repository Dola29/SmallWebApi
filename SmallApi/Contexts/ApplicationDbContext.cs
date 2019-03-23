using Microsoft.EntityFrameworkCore;
using SmallApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallApi.Contexts
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }
        public  DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
