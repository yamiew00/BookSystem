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

        /// <summary>
        /// Button "Delete"的事件
        /// 因為是Button，必定會是OnPost起手
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var bookInDb = await Context.Book.FindAsync(id);
            if(bookInDb == null)
            {
                return NotFound();
            }

            Context.Remove(bookInDb);
            await Context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
