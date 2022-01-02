using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSystem.Models
{
    public class BookSystemDbContext : DbContext
    {
        public BookSystemDbContext(DbContextOptions<BookSystemDbContext> options) : base(options)
        {

        } 

        public DbSet<Book> Book { get; set; }
    }
}
