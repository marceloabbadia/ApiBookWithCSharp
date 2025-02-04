using Microsoft.AspNetCore.Identity;
using System;

namespace BookStore.App.Data.Entities
{
    public class RentedBook
    {
        public int Id { get; set; }
        public DateTime RentedAt { get; set; }
        public DateTime? ReturnedAt { get; set; }

        public int BookId { get; set; }
        public string UserId { get; set; }
        public Book Book { get; set; }
        public IdentityUser User { get; set; }

    }
}
