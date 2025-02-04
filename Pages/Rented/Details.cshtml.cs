using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookStore.App.Data;
using BookStore.App.Data.Entities;

namespace BookStore.App.Pages.Rented
{
    public class DetailsModel : PageModel
    {
        private readonly BookStore.App.Data.BookDbContext _context;

        public DetailsModel(BookStore.App.Data.BookDbContext context)
        {
            _context = context;
        }

        public RentedBook RentedBook { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentedbook = await _context.RentedBooks.FirstOrDefaultAsync(m => m.Id == id);

            if (rentedbook is not null)
            {
                RentedBook = rentedbook;

                return Page();
            }

            return NotFound();
        }
    }
}
