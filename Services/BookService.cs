using LibraryManagement.Models;
using LibraryManagement.Repositories;
using LibraryManagement.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IAuthorRepository _authorRepository;

        public BookService(IBookRepository bookRepository, IGenreRepository genreRepository, IAuthorRepository authorRepository) { 
            _bookRepository = bookRepository;
            _genreRepository = genreRepository;
            _authorRepository = authorRepository;
        }

        public async Task<Book?> CreateBook(BookViewModel bookViewModel)
        {
            var genre = await _genreRepository.GetById(bookViewModel.GenreId);
            if (genre == null)
            {
                throw new ArgumentException("Invalid GenreId");
            }
            var author = await _authorRepository.GetById(bookViewModel.AuthorId);
            if (author == null)
            {
                throw new ArgumentException("Invalid AuthorId");
            }
            return await _bookRepository.Create(bookViewModel);
        }

        public async Task<string?> DeleteBook(int id)
        {
            
            return await (_bookRepository.Delete(id));
        }

        public async Task<IEnumerable<Book>?> GetAllBooks()
        {
            return await _bookRepository.GetAll();
        }

        public async Task<Book?> GetBookById(int id)
        {
            return await (_bookRepository.GetById(id));
        }

        public async Task<IEnumerable<Book>?> GetBooksByAuthor(int authorId)
        {
            return await _bookRepository.GetByAuthor(authorId);
        }

        public async Task<IEnumerable<Book>?> GetBooksByGenre(int genreId)
        {
            return await _bookRepository.GetByGenre(genreId);
        }

        public async Task<Book?> UpdateBook(UpdateBookViewModel updateBookViewModel)
        {
            
            return await _bookRepository.Update(updateBookViewModel);
        }
    }
}
