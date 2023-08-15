using LibraryManagement.Attributes;
using LibraryManagement.Extensions;
using LibraryManagement.Services;
using LibraryManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowedBookController : Controller
    {
        private readonly IBorrowedBookService _borrowedBookService;
        private readonly IUserService _userService;
        public BorrowedBookController(IBorrowedBookService borrowedBookService, IUserService userService )
        {
            _borrowedBookService = borrowedBookService;
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBorrowedBooks() {
            var borrowed_books = await _borrowedBookService.GetAllBorrowedBooks();
            return Ok(borrowed_books);
        }
        [HttpPost]
        [JwtAuthorize]
        public async Task<IActionResult> CreateBorrowedBook(BorrowedBookViewModel borrowedBookViewModel)
        {
            int userId = HttpContext.GetUserId();
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound("Invalid User.");
            }
            if (user.Role == 2)
            {
                return Unauthorized("Permission Denied.");
            }
            try
            {
                var book = await _borrowedBookService.CreateBorrowedBook(borrowedBookViewModel);
                return Ok(book);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        [JwtAuthorize]
        public async Task<IActionResult> DeleteBorrowedBook(int id)
        {
            int userId = HttpContext.GetUserId();
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound("Invalid User.");
            }
            if (user.Role == 2)
            {
                return Unauthorized("Permission Denied.");
            }
            try
            {
                //Dang fix dong` nay
                var res = await _borrowedBookService.DeleteBorrowedBook(id);
                return Ok(new { Message = res });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpPut]
        [JwtAuthorize] 
        public async Task<IActionResult> UpdateBorrowedBook(UpdateBorrowedBookViewModel updateBorrowedBookViewModel)
        {
            int userId = HttpContext.GetUserId();
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound("Invalid User.");
            }
            if (user.Role == 2)
            {
                return Unauthorized("Permission Denied.");
            }
            try
            {
                var res = await _borrowedBookService.UpdateBorrowedBook(updateBorrowedBookViewModel);
                if (res == null) return NotFound();
                return Ok(new { res });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetBorrowedBooksByUser(int userId)
        {
            var res =  await _borrowedBookService.GetBorrowedBooksByUser(userId);
            return Ok(res);
        }
        [HttpGet("book/{bookId}")]
        public async Task<IActionResult> GetBorrowedBooksByBook(int bookId)
        {
            var res = await _borrowedBookService.GetBorrowedBooksByBook(bookId);
            return Ok(res);
        }
    }
}
