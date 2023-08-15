using LibraryManagement.Models;
using LibraryManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace LibraryManagement.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryManagementContext _context;
        public BookRepository(LibraryManagementContext context) { 
            _context = context;
        }
        public async Task<Book?> Create(BookViewModel bookViewModel)
        {
            

            Book book = new Book
            {
                Title = bookViewModel.Title,
                Description = bookViewModel.Description,
                PublicationDate = bookViewModel.PublicationDate,
                AuthorId = bookViewModel.AuthorId,
                GenreId = bookViewModel.GenreId,
                
            };
            book.Author = await _context.Authors.FindAsync(bookViewModel.AuthorId);
            book.Genre = await _context.Genres.FindAsync(bookViewModel.GenreId);
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<string?> Delete(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(u => u.BookId == id);
            if (book == null)
            {
                throw new ArgumentException("Invalid BookId");
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return ("Remove Book (Id = " + id + ") Success");
            
        }

        public async Task<IEnumerable<Book>?> GetAll()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<IEnumerable<Book>?> GetByAuthor(int authorId)
        {
            return await _context.Books.Where(u => u.AuthorId == authorId).ToListAsync();
        }

        public async Task<IEnumerable<Book>?> GetByGenre(int genreId)
        {
            return await _context.Books.Where(u => u.GenreId == genreId).ToListAsync();
        }

        public async Task<Book?> GetById(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(u => u.BookId == id);
        }

        public async Task<Book?> Update(UpdateBookViewModel updateBookViewModel)
        {
            var book = await _context.Books.FindAsync(updateBookViewModel.BookId);

            if (book != null)
            {
                // Cập nhật thông tin sách từ BookViewModel
                if (!string.IsNullOrEmpty(updateBookViewModel.Title))
                {
                    book.Title = updateBookViewModel.Title;
                }
                if (updateBookViewModel.PublicationDate != null)
                {
                    book.PublicationDate = (DateTime)updateBookViewModel.PublicationDate;
                }
                if (updateBookViewModel.GenreId != null)
                {
                    var genre = await _context.Genres.FindAsync(updateBookViewModel.GenreId);
                    if (genre != null)
                    {
                        book.GenreId = (int)updateBookViewModel.GenreId;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid GenreId");
                    }
                }
                if (updateBookViewModel.AuthorId != null)
                {
                    var author = await _context.Authors.FindAsync(updateBookViewModel.AuthorId);
                    if (author != null)
                    {
                        book.AuthorId = (int)updateBookViewModel.AuthorId;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid AuthorId");
                    }
                }
                if (!string.IsNullOrEmpty(updateBookViewModel.Description))
                {
                    book.Description = updateBookViewModel.Description;
                }

                await _context.SaveChangesAsync();
            }

            return book;
        }
    }
}
