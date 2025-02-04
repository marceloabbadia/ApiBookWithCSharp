using BookStore.App.Repositories;

namespace BookStore.App.Pages.MyBooks
{
    [Authorize]

    public class DeleteModel : PageModel
    {
        private readonly BookRepository _bookRepository;

        public DeleteModel(BookRepository bookRepository)
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

            var book = await _bookRepository.GetBookByIdAsync(id.Value);


            if (book is not null)
            {
                Book = book;

                return Page();
            }

            return NotFound();
        }


        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
                return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _ = await _bookRepository.DeleteAsync(id.Value, userId);

            return RedirectToPage("./Index");
        }

    }
}
