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
    public class IndexModel : PageModel
    {
        private readonly BookStore.App.Data.BookDbContext _context;

        public IndexModel(BookStore.App.Data.BookDbContext context)
        {
            _context = context;
        }

        public IList<RentedBook> RentedBook { get;set; } = default!;

        public async Task OnGetAsync()
        {
            RentedBook = await _context.RentedBooks
                .Include(r => r.Book)
                .Include(r => r.User).ToListAsync();
        }
    }
}
