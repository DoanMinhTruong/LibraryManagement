using LibraryManagement.Models;
using LibraryManagement.Repositories;
using LibraryManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace LibraryManagement.Services
{
    public class BorrowedBookService : IBorrowedBookService
    {
        private readonly IBorrowedBookRepository _borrowBookRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;
        public BorrowedBookService(IBorrowedBookRepository borrowBookRepository , IBookRepository bookRepository, IUserRepository userRepository) {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _borrowBookRepository = borrowBookRepository;
        }

        public async Task<BorrowedBook?> CreateBorrowedBook(BorrowedBookViewModel borrowedBookViewModel)
        {
            
            var user = await _userRepository.GetById(borrowedBookViewModel.UserId);
            
            if (user == null)
            {
                throw new ArgumentException("Invalid UserId");
            }
            
            var book = await _bookRepository.GetById(borrowedBookViewModel.BookId);
            if (book == null)
            {
                throw new ArgumentException("Invalid BookId");
            }
            
            if(borrowedBookViewModel.ReturnDate <= DateTime.MinValue)
            {
                throw new ArgumentException("Invalid ReturnDate");
            }
            if (borrowedBookViewModel.BorrowDate <= DateTime.MinValue)
            {
                throw new ArgumentException("Invalid BorrowDate");
            }

            if(borrowedBookViewModel.BorrowDate > borrowedBookViewModel.ReturnDate || borrowedBookViewModel.BorrowDate >= DateTime.Now)
            {
                throw new ArgumentException("BorrowDate must be in the past and less than or equal to ReturnDate");
            }
            if(borrowedBookViewModel.ActualReturnDate != null)
            {
                if (borrowedBookViewModel.ActualReturnDate <= borrowedBookViewModel.BorrowDate || borrowedBookViewModel.ActualReturnDate > DateTime.Now)
                {
                    throw new ArgumentException("ActualReturnDate must be between BorrowDate and current date.");
                }
            }
            return await _borrowBookRepository.Create(borrowedBookViewModel);
        }

        public async Task<string?> DeleteBorrowedBook(int id)
        {
            return await _borrowBookRepository.Delete(id);
        }

        public async Task<IEnumerable<BorrowedBook>?> GetAllBorrowedBooks()
        {
            return await _borrowBookRepository.GetAll();
        }

        public async Task<BorrowedBook?> GetBorrowedBookById(int id)
        {
            return await _borrowBookRepository.GetById(id);
        }

        public async Task<IEnumerable<BorrowedBook>?> GetBorrowedBooksByBook(int bookId)
        {
            return await _borrowBookRepository.GetByBook(bookId);
        }

        public async Task<IEnumerable<BorrowedBook>?> GetBorrowedBooksByUser(int userId)
        {
            return await _borrowBookRepository.GetByUser(userId);
        }

        public async Task<BorrowedBook?> UpdateBorrowedBook(UpdateBorrowedBookViewModel updateBorrowedBookViewModel)
        {
            return await _borrowBookRepository.Update(updateBorrowedBookViewModel);
        }
    }
}
