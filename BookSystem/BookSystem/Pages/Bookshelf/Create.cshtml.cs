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

        //BindProperty�i�H��property�Mmodel��M�W
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
                //�Y�s�W�����\�h�����쭶��
                return Page();
            }
        }
    }
}
