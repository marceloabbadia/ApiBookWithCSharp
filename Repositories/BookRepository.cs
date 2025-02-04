using System;
using FluentResults;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BookStore.App.Repositories
{
    public class BookRepository
    {
        private readonly BookDbContext _ctx;

        public BookRepository(BookDbContext ctx)
        {
            _ctx = ctx;
        }
        public Book GetBookById(int id)
        {
            return _ctx.Books.FirstOrDefault(x => x.Id == id);

        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _ctx.Books.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<Result> UpdateBookAsync(Book book)
        {
            try
            {
                _ctx.Attach(book).State = EntityState.Modified;

                await _ctx.SaveChangesAsync();

                return Result.Ok();

            }
            catch
            {

                return Result.Fail("Error updating the book.");
            }
        }

        public async Task<Result> DeleteAsync(int bookId, string userId)
        {
            try
            {
                int res = await _ctx.Books
                     .Where(b => b.Id == bookId && b.UserId == userId)
                     .ExecuteDeleteAsync();

                return res > 0 ? Result.Ok() : Result.Fail("Book not found");


            }
            catch
            {
                return Result.Fail("Error Deleting the book");
            }
        }

        public async Task<Result> CreateBook(Book book)
        {
            try
            {
                _ctx.Books.Add(book);
                await _ctx.SaveChangesAsync();

                return Result.Ok();

            }
            catch
            {

                return Result.Fail("Error creating the book.");
            }
        }



    }
}