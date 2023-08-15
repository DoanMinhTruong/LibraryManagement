using LibraryManagement.Models;
using LibraryManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;

namespace LibraryManagement.Repositories
{
    public class BorrowBookRepository : IBorrowedBookRepository
    {
        private readonly LibraryManagementContext _context;
        public BorrowBookRepository(LibraryManagementContext context) { 
            _context = context;
        }

        public async Task<BorrowedBook?> Create(BorrowedBookViewModel borrowedBookViewModel)
        {

            
            BorrowedBook borrow_book = new BorrowedBook
            {
                UserId = borrowedBookViewModel.UserId,
                BookId = borrowedBookViewModel.BookId,
                Status = borrowedBookViewModel.Status,
                BorrowDate = (DateTime)borrowedBookViewModel.BorrowDate ,
                ReturnDate = (DateTime)borrowedBookViewModel.ReturnDate,
                
            };
            borrow_book.User = await _context.Users.FindAsync(borrowedBookViewModel.UserId);
            borrow_book.Book = await _context.Books.FindAsync(borrowedBookViewModel.BookId);

            if (borrowedBookViewModel.ActualReturnDate != null)
            {
                borrow_book.ActualReturnDate = (DateTime)borrowedBookViewModel.ActualReturnDate;
            }
            
            _context.BorrowedBooks.Add(borrow_book);
            await _context.SaveChangesAsync();
            return borrow_book;
            
        }

        public async Task<string?> Delete(int id)
        {
            var borrow_book = await _context.BorrowedBooks.FirstOrDefaultAsync(u => u.BookId == id);
            if (borrow_book == null)
            {
                throw new ArgumentException("Invalid BookId");
            }
            _context.BorrowedBooks.Remove(borrow_book);
            await _context.SaveChangesAsync();
            return ("Remove BorrowedBooks (Id = " + id + ") Success");
        }

        public async Task<IEnumerable<BorrowedBook>?> GetAll()
        {
            return await _context.BorrowedBooks.ToListAsync();
        }

        public async Task<IEnumerable<BorrowedBook>?> GetByBook(int bookId)
        {
            return await _context.BorrowedBooks.Where(u => u.BookId == bookId).ToListAsync();
        }

        public async Task<BorrowedBook?> GetById(int id)
        {
            return await _context.BorrowedBooks.FirstOrDefaultAsync(u => u.BorrowId == id);
        }

        public async Task<IEnumerable<BorrowedBook>?> GetByUser(int userId)
        {
            return await _context.BorrowedBooks.Where(u => u.UserId == userId).ToListAsync();
        }

        public async Task<BorrowedBook?> Update(UpdateBorrowedBookViewModel updateBorrowedBookViewModel)
        {
            var borrow_book = await _context.BorrowedBooks.FindAsync(updateBorrowedBookViewModel.BorrowedBookId);

            if (borrow_book != null)
            {
                // Cập nhật thông tin sách từ BookViewModel

                if ((updateBorrowedBookViewModel.ReturnDate != null) && 
                    (updateBorrowedBookViewModel.BorrowDate != null) && 
                    
                    (updateBorrowedBookViewModel.BorrowDate > updateBorrowedBookViewModel.ReturnDate || 
                    updateBorrowedBookViewModel.BorrowDate >= DateTime.Now))
                {
                    throw new ArgumentException("BorrowDate must be in the past and less than or equal to ReturnDate.");
                }
                if ((updateBorrowedBookViewModel.ActualReturnDate != null) && updateBorrowedBookViewModel.ActualReturnDate <= updateBorrowedBookViewModel.BorrowDate ||
                    updateBorrowedBookViewModel.ActualReturnDate > DateTime.Now)
                {
                    throw new ArgumentException("ActualReturnDate must be between BorrowDate and current date.");
                }
                if (updateBorrowedBookViewModel.ReturnDate != null)
                {
                    borrow_book.ReturnDate = (DateTime)updateBorrowedBookViewModel.ReturnDate;
                }
                if (updateBorrowedBookViewModel.BorrowDate != null)
                {
                    borrow_book.BorrowDate = (DateTime)updateBorrowedBookViewModel.BorrowDate;
                }
                if (updateBorrowedBookViewModel.ActualReturnDate != null)
                {
                    borrow_book.ActualReturnDate = (DateTime)updateBorrowedBookViewModel.ActualReturnDate;
                }


                if (updateBorrowedBookViewModel.BookId != null)
                {
                    var book = await _context.Books.FindAsync(updateBorrowedBookViewModel.BookId);
                    if (book != null)
                    {
                        borrow_book.BookId = (int)updateBorrowedBookViewModel.BookId;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid BookId");
                    }
                }
                if (updateBorrowedBookViewModel.UserId != null)
                {
                    var user = await _context.Users.FindAsync(updateBorrowedBookViewModel.UserId);
                    if (user != null)
                    {
                        borrow_book.UserId = (int)updateBorrowedBookViewModel.UserId;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid UserId");
                    }
                }
                if(updateBorrowedBookViewModel.Status != null)
                {
                    int current_status = borrow_book.Status;
                    if(current_status == 0 && updateBorrowedBookViewModel.Status == 1)
                    {
                        if(updateBorrowedBookViewModel.ActualReturnDate == null)
                        {
                            borrow_book.ActualReturnDate = DateTime.Now;
                        }
                    }
                    borrow_book.Status = (byte)updateBorrowedBookViewModel.Status;
                }

                await _context.SaveChangesAsync();
            }

            return borrow_book;
        }
    }
}
