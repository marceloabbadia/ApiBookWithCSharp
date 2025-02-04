using BookStore.App.Repositories;

namespace BookStore.App.Pages.MyBooks
{
    [Authorize]

    public class DetailsModel : PageModel
    {
        private readonly BookRepository _bookRepository;

        public DetailsModel(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _bookRepository.GetBookByIdAsync(id.Value);

            return Book is null ? NotFound() : Page();
        }
    }
}
