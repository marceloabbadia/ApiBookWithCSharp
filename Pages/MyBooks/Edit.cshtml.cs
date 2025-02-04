using System;
using BookStore.App.Repositories;
using FluentResults;

namespace BookStore.App.Pages.MyBooks
{

    [Authorize]

    public class EditModel : PageModel
    {
        private readonly BookRepository _bookRepository;

        public EditModel(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var book = await _bookRepository.GetBookByIdAsync(id.Value);

            if (book == null || book.UserId != userId)
            {
                return NotFound();
            }

            if (book == null)
            {
                return NotFound();
            }
            Book = book;
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

            Book.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Result result = await _bookRepository.UpdateBookAsync(Book);

            if (result.IsFailed)
            {

                return NotFound();
            }
            else
            {
                return RedirectToPage("./Index");

            }

        }


        private bool BookExists(int id)
        {
            return true;
            //return _context.Books.Any(e => e.Id == id);
        }
    }
}
