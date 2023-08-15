using LibraryManagement.Models;
using LibraryManagement.ViewModels;

namespace LibraryManagement.Repositories
{
    public interface IBorrowedBookRepository
    {
        Task<BorrowedBook?> GetById(int id);
        Task<IEnumerable<BorrowedBook>?> GetByUser(int userId);
        Task<IEnumerable<BorrowedBook>?> GetByBook(int bookId);

        Task<IEnumerable<BorrowedBook>?> GetAll();
        Task<BorrowedBook?> Create(BorrowedBookViewModel borrowedBookViewModel);
        Task<BorrowedBook?> Update(UpdateBorrowedBookViewModel updateBorrowedBookViewModel);
        Task<string?> Delete(int id);
    }
}
