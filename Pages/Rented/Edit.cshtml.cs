using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.App.Data;
using BookStore.App.Data.Entities;

namespace BookStore.App.Pages.Rented
{
    public class EditModel : PageModel
    {
        private readonly BookStore.App.Data.BookDbContext _context;

        public EditModel(BookStore.App.Data.BookDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RentedBook RentedBook { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentedbook =  await _context.RentedBooks.FirstOrDefaultAsync(m => m.Id == id);
            if (rentedbook == null)
            {
                return NotFound();
            }
            RentedBook = rentedbook;
           ViewData["BookId"] = new SelectList(_context.Books, "Id", "Author");
           ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RentedBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentedBookExists(RentedBook.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RentedBookExists(int id)
        {
            return _context.RentedBooks.Any(e => e.Id == id);
        }
    }
}
