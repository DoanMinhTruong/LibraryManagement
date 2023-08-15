using LibraryManagement.Models;
using LibraryManagement.ViewModels;

namespace LibraryManagement.Repositories
{
    public interface IBookRepository
    {
        Task<Book?> GetById(int id);
        Task<IEnumerable<Book>?> GetByGenre(int genreId);
        Task<IEnumerable<Book>?> GetByAuthor(int authorId);
        Task<IEnumerable<Book>?> GetAll();
        Task<Book?> Create(BookViewModel bookViewModel);
        Task<Book?> Update(UpdateBookViewModel updateBookViewModel);
        Task<string?> Delete(int id);

    }
}
