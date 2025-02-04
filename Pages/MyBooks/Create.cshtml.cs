using BookStore.App.Repositories;
using FluentResults;

namespace BookStore.App.Pages.MyBooks
{
    [Authorize]
    public class CreateModel : PageModel
    {

        private readonly BookRepository _bookRepository;

        public CreateModel(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Book.UserId");

            if (!ModelState.IsValid)
            {
                return Page();
            }


            Book.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Result result = await _bookRepository.CreateBook(Book);

            return result is null ? NotFound() : RedirectToPage("./Index");


    
        }
    }
}
