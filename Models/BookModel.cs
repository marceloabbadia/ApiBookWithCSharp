namespace BookStore.App.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Isbn { get; set; }

        public string Category { get; set; }

        public string UserId { get; set; }

        public string UserEmail { get; set; }

    }
}

