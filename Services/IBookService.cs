using LibraryManagement.Models;
using LibraryManagement.ViewModels;

namespace LibraryManagement.Services
{
    public interface IBookService
    {
        Task<Book?> GetBookById(int id);
        Task<IEnumerable<Book>?> GetBooksByGenre(int genreId);
        Task<IEnumerable<Book>?> GetBooksByAuthor(int authorId);
        Task<IEnumerable<Book>?> GetAllBooks();
        Task<Book?> CreateBook(BookViewModel bookViewModel);
        Task<Book?> UpdateBook(UpdateBookViewModel updateBookViewModel);
        Task<string?> DeleteBook(int id);
    }
}
