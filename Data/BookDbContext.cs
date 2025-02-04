using BookStore.App.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.App.Data;

public class BookDbContext : IdentityDbContext
{
    public BookDbContext(DbContextOptions<BookDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<RentedBook> RentedBooks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>().Property(b => b.PublishedAt)
            .HasColumnType("varchar(100)");

        modelBuilder.Entity<Book>().HasIndex(b => b.Isbn).IsUnique();

        // RentedBook Configurations

        modelBuilder.Entity<RentedBook>().Property(p => p.RentedAt).HasColumnType("datetime2(0)");
        modelBuilder.Entity<RentedBook>().Property(p => p.ReturnedAt).HasColumnType("datetime2(0)");
        modelBuilder.Entity<RentedBook>().Property(p => p.UserId).IsRequired();
    }

}



