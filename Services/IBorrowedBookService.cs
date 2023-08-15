using LibraryManagement.Models;
using LibraryManagement.ViewModels;

namespace LibraryManagement.Services
{
    public interface IBorrowedBookService
    {
        Task<BorrowedBook?> GetBorrowedBookById(int id);
        Task<IEnumerable<BorrowedBook>?> GetBorrowedBooksByUser(int userId);
        Task<IEnumerable<BorrowedBook>?> GetBorrowedBooksByBook(int bookId);

        Task<IEnumerable<BorrowedBook>?> GetAllBorrowedBooks();
        Task<BorrowedBook?> CreateBorrowedBook(BorrowedBookViewModel borrowedBookViewModel);
        Task<BorrowedBook?> UpdateBorrowedBook(UpdateBorrowedBookViewModel updateBorrowedBookViewModel);
        Task<string?> DeleteBorrowedBook(int id);
    }
}
