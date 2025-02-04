
namespace BookStore.App.Pages.MyBooks
{
    public class IndexModel : PageModel
    {
        //public IList<Book> Books { get; set; }

        private readonly BookDbContext _ctx;

        public IndexModel(BookDbContext ctx)
        {
            _ctx = ctx;
        }

        public IList<BookModel> Books {  get; set; }

        public async Task OnGetAsync()
        {
            // Carrega tudo User e Books por causa do Include. Resolver mas fica over
            //Books = await _ctx.Books.Include(u => u.User).ToListAsync();

            Books = await (from b in _ctx.Books
                        join u in _ctx.Users on b.UserId equals u.Id
                        select new BookModel
                        {
                            Id = b.Id,
                            Title = b.Title,
                            Isbn = b.Isbn,
                            Category = b.Category,
                            UserId = b.UserId,
                            UserEmail = u.Email

                        }).ToListAsync();
        }
    }
}

