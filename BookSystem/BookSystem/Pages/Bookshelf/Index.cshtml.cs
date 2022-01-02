using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookSystem.Pages.Bookshelf
{
    public class IndexModel : PageModel
    {
        private BookSystemDbContext Context;

        public IEnumerable<Book> Books { get; set; }

        public IndexModel(BookSystemDbContext bookSystemDbContext)
        {
            Context = bookSystemDbContext;
        }

        public async Task OnGet()
        {
            Books = await Context.Book.ToListAsync();
        }
    }
}
