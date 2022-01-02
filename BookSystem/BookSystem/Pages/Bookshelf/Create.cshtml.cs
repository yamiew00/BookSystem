using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSystem.Pages.Bookshelf
{
    public class CreateModel : PageModel
    {
        private BookSystemDbContext Context;

        public CreateModel(BookSystemDbContext bookSystemDbContext)
        {
            Context = bookSystemDbContext;
        }

        //BindProperty可以讓property和model對映上
        [BindProperty]
        public Book Book { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await Context.Book.AddAsync(Book);
                await Context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                //若新增不成功則維持原頁面
                return Page();
            }
        }
    }
}
