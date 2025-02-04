using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookStore.App.Data;
using BookStore.App.Data.Entities;

namespace BookStore.App.Pages.Rented
{
    public class CreateModel : PageModel
    {
        private readonly BookStore.App.Data.BookDbContext _context;

        public CreateModel(BookStore.App.Data.BookDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BookId"] = new SelectList(_context.Books, "Id", "Title");
        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
            return Page();
        }

        [BindProperty]
        public RentedBook RentedBook { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RentedBooks.Add(RentedBook);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
